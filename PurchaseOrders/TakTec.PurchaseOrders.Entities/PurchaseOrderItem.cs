using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TakTec.PurchaseOrders.Entities
{
    public class PurchaseOrderItem:EntityBase 
    {

        public PurchaseOrderItem(float denomination,
            int quantity, String ownerId) : base(ownerId,ResourceTypes.NONE) {
            this.Denomination = denomination;
            this.Quantity = quantity;
        }

        public float Denomination { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public PurchaseOrder PurchaseOrder { get; set; }

    }
}
