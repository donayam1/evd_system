using System;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class PurchaseOrderItemModel
    {
        public String? Id { get; set; }
        public float Denomination { get; set; }
        public int Quantity { get; set; }
        public String? OwnerId { get; set; } = default!;

    }
}
