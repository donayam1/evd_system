using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class PurchaseOrderModel
    {
        public String? Id { get; set; }
        public String PurchaseOrderNumber { get; set; } = default!;
        public List<PurchaseOrderItemModel> Items { get; set; } 
            = new List<PurchaseOrderItemModel>();
    }
}
