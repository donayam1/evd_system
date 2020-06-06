using System;
using System.Collections.Generic;
using System.Text;

namespace Vouchers.ViewModels
{
    public class VoucherBatchModel
    {
        
        public String PurchaserOrderNumber { get; set; } = default!;
        public String? Id { get; set; }

        public String Batch { get; set; } = default!;
        public String StopDate { get; set; } = default!;
        public String StartSequence { get; set; } = default!;
        public int Quantity { get; set; } = default!;
        public float Denomination { get; set; } = default!;
    }
}
