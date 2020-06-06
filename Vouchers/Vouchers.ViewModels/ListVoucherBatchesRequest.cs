using EthioArt.Backend.Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using Vouchers.Data.Enumerations;

namespace Vouchers.ViewModels
{
    public class ListVoucherBatchesRequest: PagedItemRequestBase , ISynchronizeItemRequestBase
    {        
        public DateTime? FromDate { get ; set ; }
        public bool IsSyncing { get; set; } = false;
        public DateTime? ToDate { get ; set ; }

        public VoucherBatchStatus BatchStatus { get; set; } = 
            VoucherBatchStatus.Activated;

    }
}
