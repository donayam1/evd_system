using System;
using System.Collections.Generic;
using System.Text;

namespace Vouchers.ViewModels
{
    public class VoucherBatchModel
    {
       private String PurchaserOrderNumber { get; set; }
       private String Batch { get; set; }
       private String StopDate { get; set; }
       private String StartSequence { get; set; }
       private int Quantity { get; set; }
       private float Denomination { get; set; }
    }
}
