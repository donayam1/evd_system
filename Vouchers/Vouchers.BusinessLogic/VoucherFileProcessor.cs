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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR;
using TakTec.Users.Constants;
using TakTec.Accounting.Data.Abstractions;
using System.Linq;
using TakTec.Accounting.BusinessLogic.Abstractions;

namespace Vouchers.BusinessLogic
{
    public class VoucherFileProcessor : IVoucherFileProcessor
    {
        private static readonly Object SystemAirTimeUpdateLock = new Object();
        private readonly VoucherFileParameters _voucherFileParameters;
        private readonly ILogger<VoucherFileProcessor> _logger;
        private readonly IStorage _storage;

        private readonly IVoucherBatchRepository _voucherBatchRepository;
        private readonly IUserVoucherRepository _userVoucherRepository;
        //private readonly IServiceProvider _serviceProvider;
        //private readonly IHubContext<VoucherSignalHub> _hubContext;
        private readonly IVoucherStatusNotificationService _voucherStatusNotificationService;
        //private readonly IAirTimeRepository _airTimeRepository;
        private readonly IAirTimeService _airTimeService;
        public VoucherFileProcessor(
            //IServiceProvider serviceProvider,
            IOptions<VoucherFileParameters> voucherFileParameterOptions,
            ILogger<VoucherFileProcessor> logger,
            IStorage storage,
            IVoucherStatusNotificationService voucherStatusNotificationService,
            IAirTimeService airTimeService//,
                                          //IHubContext<VoucherSignalHub> hubContext
            )
        {
            //_serviceProvider = serviceProvider ??
            //    throw new ArgumentNullException(nameof(IServiceProvider));
            _voucherFileParameters = voucherFileParameterOptions?.Value ??
                throw new ArgumentNullException(nameof(IOptions<VoucherFileParameters>));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));

            _voucherBatchRepository = _storage.GetRepository<IVoucherBatchRepository>() ??
                throw new ArgumentNullException(nameof(IVoucherBatchRepository));
            _userVoucherRepository = _storage.GetRepository<IUserVoucherRepository>() ??
                throw new ArgumentNullException(nameof(IUserVoucherRepository));
            //_airTimeRepository = _storage.GetRepository<IAirTimeRepository>() ??
            //    throw new ArgumentNullException(nameof(IAirTimeRepository));
            _airTimeService = airTimeService ?? throw new ArgumentNullException(nameof(IAirTimeService));
            //_hubContext = hubContext;
            _voucherStatusNotificationService = voucherStatusNotificationService ??
                throw new ArgumentNullException(nameof(IVoucherStatusNotificationService));

        }


        public async Task ProcessFile(String path, String poId)
        {
            UploadVoucherResponse response0 = new UploadVoucherResponse()
            {
                Status = false,
            };
            try
            {
                using StreamReader f = new StreamReader(path);

                String? line;
                Boolean readingHeader = true;
                Boolean endFound = false;
                int lineNumber = 0;
                int airTime = 0;
                VoucherBatch batch = new VoucherBatch(poId, "", DateTime.Now, 0, 0, 0);
                while ((line = f.ReadLine()) != null)
                {
                    lineNumber++;
                    if (readingHeader)
                    {

                        VoucherFileParameterTypes type = getType(line, out String value);
                        if (type == VoucherFileParameterTypes.Begin)
                        {
                            readingHeader = false;
                            continue;
                        }
                        else if (type == VoucherFileParameterTypes.UNKnowen) {
                            throw new Exception($"Error reading file {line}");
                            
                        }
                        updateBatch(batch, value, type);

                    }
                    else  //Reading pins
                    {
                        VoucherFileParameterTypes type = getType(line, out String value);
                        if (type == VoucherFileParameterTypes.End)
                        {
                            endFound = true;
                            break;
                        }
                        Voucher v = GetVoucher(line, lineNumber, batch.Id);
                        //CreateUserVoucher(poId, v.Id);
                        batch.Vouchers.Add(v);
                        
                    }
                }
                if (!this.validateVoucherBatch(batch)) {
                    throw new Exception($"Voucher batch validation failed for file {path}.");
                }

                if (endFound == false)
                {
                    _logger.LogWarning($"Voucher file {path} does not have end tag");
                }

                lock (SystemAirTimeUpdateLock) // Lock and update the system air time.
                    //This might not be required as only the one file is processed at a time
                {
                    airTime = (int)batch.Denomination * batch.Vouchers.Count;
                    var sysairTime = _airTimeService.GetSystemAirTime();// _airTimeRepository.WithOwnerItemId(RoleTypeConstants.RoleNameSystem).FirstOrDefault();
                    if (sysairTime == null) {
                        throw new NullReferenceException($" System air time not found.");
                    }                
                    sysairTime.Amount += airTime;

                    _voucherBatchRepository.Create(batch);
                    _storage.Save();
                }
                response0.Status = true;
            }
            catch (FileNotFoundException e)
            {
                _logger.LogError($"file {path} not found. ");
                response0.Messages.Add(
                         new Message("Unknowen Error ..... Please contact the administrator.",
                         Messages.Enumeration.MessageTypes.USER_ERROR_REPORT, "200")
                     );
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException, e.Message);
                response0.Messages.Add(
                        new Message($"Error: {e.Message}. Please contact the administrator.",
                        Messages.Enumeration.MessageTypes.USER_ERROR_REPORT, "200")
                    );
            }
            finally
            {

            }
            if (response0.Status == true) {
                response0.Messages.Add(
                         new Message("Sucessfully uploaded voucher file.",
                         Messages.Enumeration.MessageTypes.USER_MESSAGE, "200")
                     );
            }
          
            await this._voucherStatusNotificationService.NotifyUploadVoucherStatus(response0);
        }

        bool validateVoucherBatch(VoucherBatch batch) {
            if (String.IsNullOrWhiteSpace(batch.Batch)) {

                return false;
            }
            return true;
        }

        void updateBatch(VoucherBatch batch, string line, VoucherFileParameterTypes type)
        {
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
                    batch.PurchaserOrderId = line;
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
                    DateTime stopDate = DateTime.ParseExact(line, "yyyyMMdd",
                        CultureInfo.InvariantCulture);
                    batch.StopDate = stopDate;
                    break;

                case VoucherFileParameterTypes.VoucherType:
                    break;
                default:
                    break;


            }

        }


        private Voucher GetVoucher(String fileLine, int lineNumber, String batchId)
        {

            String[] items = fileLine.Split(" ");

            if (items.Length != 2)
            {
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

            VoucherStatus vs = new VoucherStatus(v.Id,Data.Enumerations.VoucherStatusTypes.Available);
            v.VoucherStatuses.Add(vs);

            //UserVoucher userVoucher = new UserVoucher("",RoleTypeConstants.RoleNameSupperAdmin, v.Id);
            //_userVoucherRepository.Create(userVoucher);

            return v;
        }

        //private void CreateUserVoucher(String poId,String voucherId) {
        //    UserVoucher userVoucher = new UserVoucher(poId, RoleTypeConstants.RoleNameSupperAdmin, voucherId);
        //    _userVoucherRepository.Create(userVoucher);
        //}



        private VoucherFileParameterTypes getType(String parameter0, out String value)
        {
            String[] parameters = parameter0.Split(":");
            String parameter = parameters[0];
            if (parameters.Length > 1)
                value = parameters[1];
            else
            {
                value = parameter0;
            }
            if (String.IsNullOrWhiteSpace(parameter))
            {
                return VoucherFileParameterTypes.UNKnowen;
            }

            if (String.Compare(parameter, this._voucherFileParameters.PoNo, true) == 0)
            {
                return VoucherFileParameterTypes.PoNo;
            }
            else if (String.Compare(parameter, this._voucherFileParameters.FaceValue, true) == 0)
            {
                return VoucherFileParameterTypes.FaceValue;
            }
            else if (String.Compare(parameter, this._voucherFileParameters.Quantity, true) == 0)
            {
                return VoucherFileParameterTypes.Quantity;
            }
            else if (String.Compare(parameter, this._voucherFileParameters.StopDate, true) == 0)
            {
                return VoucherFileParameterTypes.StopDate;
            }
            else if (String.Compare(parameter, this._voucherFileParameters.VoucherType, true) == 0)
            {
                return VoucherFileParameterTypes.VoucherType;
            }
            else if (String.Compare(parameter, this._voucherFileParameters.StartSequence, true) == 0)
            {
                return VoucherFileParameterTypes.Start_Sequence;
            }
            else if (String.Compare(parameter, this._voucherFileParameters.Batch, true) == 0)
            {
                return VoucherFileParameterTypes.Batch;
            }
            else if (String.Compare(parameter, this._voucherFileParameters.Begin, true) == 0)
            {
                return VoucherFileParameterTypes.Begin;
            }
            else if (String.Compare(parameter, this._voucherFileParameters.End, true) == 0)
            {
                return VoucherFileParameterTypes.End;
            }

            return VoucherFileParameterTypes.UNKnowen;
        }


    }
}
