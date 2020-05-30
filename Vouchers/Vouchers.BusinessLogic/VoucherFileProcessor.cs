using ExtCore.Data.Abstractions;
using Messages.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.Configurations;
using Vouchers.Data.Abstractions;
using Vouchers.Data.Entities;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic
{
    public class VoucherFileProcessor: IVoucherFileProcessor
    {
        private readonly VoucherFileParameters voucherFileParameters;
        private readonly ILogger<VoucherFileProcessor> _logger;
        private readonly IStorage _storage;
        //private readonly IVouchersRepository _vouchersRepository;
        private readonly IVoucherBatchRepository _voucherBatchRepository;
        public VoucherFileProcessor(IOptions<VoucherFileParameters> voucherFileParameterOptions,
            ILogger<VoucherFileProcessor> logger,
            IStorage storage) {
            voucherFileParameters = voucherFileParameterOptions?.Value ??
                throw new ArgumentNullException(nameof(IOptions<VoucherFileParameters>));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            //_vouchersRepository = _storage.GetRepository<IVouchersRepository>() ??
            //    throw new ArgumentNullException(nameof(IVouchersRepository));
            _voucherBatchRepository = _storage.GetRepository<IVoucherBatchRepository>()??
                throw new ArgumentNullException(nameof(IVoucherBatchRepository));

        }
        public VoucherFileProcessor(VoucherFileParameters parameters) {
          
        }

        public async Task<UploadVoucherResponse> ProcessFile(String path) {

            UploadVoucherResponse response0 = new UploadVoucherResponse()
            {
                Status = false,                
            };
            try
            {
                using StreamReader f = new StreamReader(path);

                String line;
                Boolean readingHeader = true;
                Boolean endFound = false;
                int lineNumber = 0;
                VoucherBatch batch = new VoucherBatch("", "", DateTime.Now, 0, 0, 0);
                while ((line = f.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    lineNumber++;
                    if (readingHeader)
                    {
                        
                        VoucherFileParameterTypes type = getType(line,out String value);
                        if (type == VoucherFileParameterTypes.Begin) {
                            readingHeader = false;
                            continue;
                        }
                        updateBatch(batch, value, type);
                        
                    }
                    else  //Reading pins
                    {
                        VoucherFileParameterTypes type = getType(line,out String value);
                        if (type == VoucherFileParameterTypes.End)
                        {
                            endFound = true;
                            break;
                        }
                        Voucher v = GetVoucher(line,lineNumber, batch.Id);
                        batch.Vouchers.Add(v);
                    }
                }

                if (endFound == false) {
                    _logger.LogWarning($"Voucher file {path} does not have end tag");
                }


                _voucherBatchRepository.Create(batch);
                _storage.Save();
            }
            catch (FileNotFoundException e)
            {
                _logger.LogError($"file {path} not found. ");
                response0.Messages.Add(
                         new Message("Unknowen Error ..... Please contact the administrator.",
                         Messages.Enumeration.MessageTypes.USER_ERROR_REPORT, "200")
                     );
                return response0;
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException, e.Message);
                response0.Messages.Add(
                        new Message("Unknowen Error ..... Please contact the administrator.",
                        Messages.Enumeration.MessageTypes.USER_ERROR_REPORT, "200")
                    );
                return response0;
            }
            finally{ 
            
            }
            response0.Messages.Add(
                       new Message("Sucessfully uploaded voucher file.",
                       Messages.Enumeration.MessageTypes.USER_MESSAGE, "200")
                   );
            response0.Status = true;

            return response0;
        }

        void updateBatch(VoucherBatch batch, string line, VoucherFileParameterTypes type) {
            switch (type)
            {
                case VoucherFileParameterTypes.Batch:
                    batch.Batch = line;
                    break;
                case VoucherFileParameterTypes.Begin:
                    //readingHeader = false;
                    break;
                case VoucherFileParameterTypes.End:
                    throw new Exception($"End tag {line} found  before reading voucher numbers");
                case VoucherFileParameterTypes.FaceValue:
                    bool res = float.TryParse(line, out float faceValue);
                    if (res == true)
                    {
                        batch.Denomination = faceValue;
                    }
                    else
                    {
                        throw new Exception($"Unknowen face value {line} while processing voucher file");
                    }
                    break;
                case VoucherFileParameterTypes.PoNo:
                    batch.PurchaserOrderNumber = line;
                    break;
                case VoucherFileParameterTypes.Quantity:
                    bool res0 = int.TryParse(line, out int quantity);
                    if (res0 == true)
                    {
                        batch.Quantity = quantity;
                    }
                    else
                    {
                        throw new Exception($"Unknowen quantity {line} while processing vocher file");
                    }
                    break;
                case VoucherFileParameterTypes.Start_Sequence:
                    bool res1 = int.TryParse(line, out int sseq);
                    if (res1 == true)
                    {
                        batch.StartSequence = sseq;
                    }
                    else
                    {
                        throw new Exception($"Unknowen start sequence {line} while processing vocher file");
                    }
                    break;
                case VoucherFileParameterTypes.StopDate:
                    DateTime stopDate = DateTime.ParseExact(line,"yyyyMMdd",
                        CultureInfo.InvariantCulture);
                    batch.StopDate = stopDate;
                    break;

                case VoucherFileParameterTypes.VoucherType:
                    break;
                default:
                    break;


            }
            
        }


        public Voucher GetVoucher(String fileLine,int lineNumber,String batchId) {
            
            String[] items = fileLine.Split(" ");

            if (items.Length != 2) {
                throw new Exception($"Invalid voucher line {lineNumber} - {fileLine}");
            }

            Voucher v = new Voucher(batchId, 0, 0);

            bool res1 = int.TryParse(items[0], out int serialNumber);
            if (res1 == true)
            {
                v.SerialNumber = serialNumber;
            }
            else
            {
                throw new Exception($"invalid serial number {fileLine} while processing vocher file");
            }

            bool res2 = int.TryParse(items[0], out int pinNumber);
            if (res2 == true)
            {
                v.PinNumber = pinNumber;
            }
            else
            {
                throw new Exception($"invalid pin number {lineNumber} while processing vocher file");
            }

            return v;
        }

        private VoucherFileParameterTypes getType(String parameter0, out String value)
        {
            String []parameters = parameter0.Split(":");
            String parameter = parameters[0];
            if (parameters.Length > 1)
                value = parameters[1];
            else {
                value = "";
            }
            if (String.IsNullOrWhiteSpace(parameter)) {
                return VoucherFileParameterTypes.UNKnowen;
            }

            if (String.Compare(parameter, this.voucherFileParameters.PoNo, true) == 0)
            {
                return VoucherFileParameterTypes.PoNo;
            }
            else if (String.Compare(parameter, this.voucherFileParameters.FaceValue, true) == 0)
            {
                return VoucherFileParameterTypes.FaceValue;
            }
            else if (String.Compare(parameter, this.voucherFileParameters.Quantity, true) == 0)
            {
                return VoucherFileParameterTypes.Quantity;
            }
            else if (String.Compare(parameter, this.voucherFileParameters.StopDate, true) == 0)
            {
                return VoucherFileParameterTypes.StopDate;
            }
            else if (String.Compare(parameter, this.voucherFileParameters.VoucherType, true) == 0)
            {
                return VoucherFileParameterTypes.VoucherType;
            }
            else if (String.Compare(parameter, this.voucherFileParameters.Start_Sequence, true) == 0)
            {
                return VoucherFileParameterTypes.Start_Sequence;
            }
            else if (String.Compare(parameter, this.voucherFileParameters.Batch, true) == 0)
            {
                return VoucherFileParameterTypes.Batch;
            }
            else if (String.Compare(parameter, this.voucherFileParameters.Begin, true) == 0)
            {
                return VoucherFileParameterTypes.Begin;
            }
            else if (String.Compare(parameter, this.voucherFileParameters.End, true) == 0)
            {
                return VoucherFileParameterTypes.End;
            }

            return VoucherFileParameterTypes.UNKnowen;
        }


    }
}
