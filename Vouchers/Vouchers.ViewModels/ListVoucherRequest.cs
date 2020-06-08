using EthioArt.Backend.Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using Vouchers.Data.Enumerations;

namespace Vouchers.ViewModels
{
    public class ListVoucherRequest: PagedItemRequestBase 
    {
        /// <summary>
        /// If Batch is specified 
        /// </summary>
        public String? BatchId { get; set; } = default!;
        public String? PurchaseOrderId { get; set; } = default!;
        public VoucherStatusTypes VoucherStatus { get; set; } = default!;
        public bool IsSyncing { get; set; } = false;
        public String? FromDate { get; set; }
        public String? ToDate { get; set; }
    }
}
