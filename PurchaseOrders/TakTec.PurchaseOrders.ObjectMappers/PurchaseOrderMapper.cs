using System;
using System.Collections.Generic;
using System.Linq;
using TakTec.PurchaseOrders.Entities;
using TakTec.PurchaseOrders.ViewModels;

namespace TakTec.PurchaseOrders.ObjectMappers
{
    public static class PurchaseOrderMapper
    {
        public static PurchaseOrderItem ToDomainModel(this PurchaseOrderItemModel itemModel,String poId) {
            PurchaseOrderItem item = new PurchaseOrderItem(itemModel.Denomination, itemModel.Quantity, poId) {                
            };
            return item;
        }

        public static List<PurchaseOrderItem> ToDomainModel(this List<PurchaseOrderItemModel> itemModels, String poId)
        {
            return itemModels.Select(x => x.ToDomainModel(poId)).ToList();
        }

        public static PurchaseOrder ToDomainModel(this NewPurchaseOrderModel newPurchaseOrder,String creatorUserId) {

            String ownerId = newPurchaseOrder.Self ? creatorUserId : newPurchaseOrder.UserId;
            PurchaseOrder purchaseOrder = new PurchaseOrder(creatorUserId, ownerId, newPurchaseOrder.PurchaseOrderNumber);
            purchaseOrder.OrderItems = newPurchaseOrder.Items.ToDomainModel(purchaseOrder.Id);

            return purchaseOrder;
        }



 
    }
}
