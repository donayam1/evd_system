using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class PeekVoucherRequest
    {
        [Required]
        public String BatchId { get; set; } = default!;
    }
}
