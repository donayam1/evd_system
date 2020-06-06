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

        public static PurchaseOrderItemModel ToViewModel(this PurchaseOrderItem item)
        {
            PurchaseOrderItemModel res = new PurchaseOrderItemModel()
            {
                Denomination = item.Denomination,
                Id = item.Id,
                Quantity = item.Quantity,
                OwnerId = item.OwnerId
            };
            return res;
        }

        public static List<PurchaseOrderItemModel> ToViewModel(this List<PurchaseOrderItem> items) {
            return items.Select(x => x.ToViewModel()).ToList();
        }

        public static List<PurchaseOrderItem> ToDomainModel(this List<PurchaseOrderItemModel> itemModels, String poId)
        {
            return itemModels.Select(x => x.ToDomainModel(poId)).ToList();
        }

        public static PurchaseOrder ToDomainModel(this InternalPurchaseOrderRequest newPurchaseOrder,
            String creatorUserId,String ownerRoleName) {

            String ownerId = ownerRoleName;// newPurchaseOrder.Self ? creatorUserId : newPurchaseOrder.UserId;
            PurchaseOrder purchaseOrder = 
                new PurchaseOrder(creatorUserId, ownerId, 
                newPurchaseOrder.PurchaseOrderNumber, newPurchaseOrder.IsExternalOrder);

            purchaseOrder.OrderItems = newPurchaseOrder.Items.ToDomainModel(purchaseOrder.Id);

            return purchaseOrder;
        }


        public static PurchaseOrderModel ToViewModel(this PurchaseOrder purchaseOrder)
        {
            PurchaseOrderModel model = new PurchaseOrderModel()
            {
                 Id = purchaseOrder.Id,
                 PurchaseOrderNumber = purchaseOrder.PurchaseOrderNumber,
                 Items = purchaseOrder.OrderItems.ToViewModel()
            };

            
            return model;
        }
        public static NewPurchaseOrderResult ToNewPoViewModel(this PurchaseOrder purchaseOrder)
        {
            NewPurchaseOrderResult model = new NewPurchaseOrderResult()
            {
                Id = purchaseOrder.Id,
                PurchaseOrderNumber = purchaseOrder.PurchaseOrderNumber,
                Items = purchaseOrder.OrderItems.ToViewModel()
            };


            return model;
        }
        

        public static List<PurchaseOrderModel> ToViewModel(this List<PurchaseOrder> purchaseOrders) {
            return purchaseOrders.Select(x => x.ToViewModel()).ToList();
        }




    }
}
