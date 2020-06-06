using ExtCore.Data.Abstractions;
using Messages.Logging.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.Data.Abstractions;
using Vouchers.ViewModels;
using System.Linq;
using Vouchers.ObjectMapper;

namespace Vouchers.BusinessLogic
{
    public class VoucherBatchService : IVoucherBatchService
    {
        private readonly IStorage _storage;
        private readonly IVoucherBatchRepository _voucherBatchRepository;
        private readonly ILogger<IVoucherBatchService> _logger;

        public VoucherBatchService(IStorage storage,
            ILogger<IVoucherBatchService> logger) {
            this._storage = storage ?? 
                throw new ArgumentNullException(nameof(storage));
            this._voucherBatchRepository = _storage.GetRepository<IVoucherBatchRepository>() ??
                throw new ArgumentNullException(nameof(IVoucherBatchRepository));
            this._logger = logger ??
                throw new ArgumentNullException(nameof(ILogger<IVoucherBatchService>));
        }

        public bool ActivateBatch(string batchId)
        {
            var batch = _voucherBatchRepository.WithKey(batchId);
            if (batch == null) {
                _logger.AddUserError("Unknowen voucher batch");
                return false;
            }

            batch.IsAproved = true;
            try {
                _storage.Save();
                return true;
            } catch (Exception e) {
                _logger.AddUserError($"Unknowen error,Please " +
                    $"contact the administrator ");
                _logger.LogError(e,$"{e.Message}-{e.InnerException}");

            }
            return false;

            //throw new NotImplementedException();
        }

        public List<VoucherBatchModel> ListBatches(ListVoucherBatchesRequest request)
        {
            bool isActive = request.BatchStatus == Data.Enumerations.VoucherBatchStatus.Activated ? true : false;
            var res = this._voucherBatchRepository.All(request.IsSyncing, request.FromDate, request.ToDate)
                .Where(x => x.IsAproved == isActive).ToList().ToViewModel();

            return res;
                
        }
    }
}
