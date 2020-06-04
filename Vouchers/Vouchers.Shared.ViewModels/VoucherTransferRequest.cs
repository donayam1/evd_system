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
        public List<VoucherTransferRequestItem> TransferRequestItems { get; set; }
            = new List<VoucherTransferRequestItem>();
    }
}
