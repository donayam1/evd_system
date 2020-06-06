using System;
using System.Collections.Generic;
using System.Text;

namespace Vouchers.Shared.ViewModels
{

    public class VoucherTransferRequestItem { 
        public float Denomination { get; set; }
        public int Quantity { get; set; }

    }
    public class VoucherTransferRequest
    {
        public String? BatchId { get; set; }
        public bool IsApproved { get; set; } = true;
        public String PurchaseOrderId { get; set; } = default!;

        public List<VoucherTransferRequestItem> TransferRequestItems { get; set; }
            = new List<VoucherTransferRequestItem>();
    }
}
