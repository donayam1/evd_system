using System;
using System.Collections.Generic;
using System.Text;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic.Abstractions
{
    public interface IVoucherBatchService
    {
        bool ActivateBatch(String batchId);
        List<VoucherBatchModel> ListBatches(ListVoucherBatchesRequest request); 
    }
}
