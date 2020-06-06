using EthioArt.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;

namespace TakTec.PurchaseOrders.Entities
{
    public class PurchaseOrder:EntityBase 
    {
        public PurchaseOrder(String creatorUserId, String ownerId,
            String purchaseOrderNumber,
            Boolean isExternalOrder) :
            base(ownerId,EthioArt.Data.Enumerations.ResourceTypes.GROUP) {
            this.PurchaseOrderNumber = purchaseOrderNumber;
            this.CreatorUserId = creatorUserId;
            this.IsAproved = false;
            this.IsExternalOrder = isExternalOrder;
        }

        public String PurchaseOrderNumber { get; set; }
        public Boolean IsExternalOrder { get; set; } = false;
        public List<PurchaseOrderItem> OrderItems { get; set; } 
            = new List<PurchaseOrderItem>();
                
    }
}
