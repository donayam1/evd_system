using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class PurchaseOrderModel
    {
        public String? Id { get; set; }
        public String PurchaseOrderNumber { get; set; } = default!;

        [Required]
        public List<PurchaseOrderItemModel> Items { get; set; } 
            = new List<PurchaseOrderItemModel>();
    }
}
