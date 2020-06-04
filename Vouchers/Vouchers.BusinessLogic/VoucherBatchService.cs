using System;
using System.Collections.Generic;
using System.Text;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic
{
    public class VoucherBatchService : IVoucherBatchService
    {
        public bool ActivateBatch(string batchId)
        {
            throw new NotImplementedException();
        }

        public List<VoucherBatchModel> ListBatches(ListVoucherBatchesRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
