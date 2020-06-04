using System;
using TakTec.PurchaseOrders.ViewModels;

namespace TakTec.PurchaseOrders.BusinessLogic.Abstractions
{
    public interface IPurchaseOrderService
    {

        PurchaseOrderModel? CreatePurchaseOrder(NewPurchaseOrderModel request);
    }
}
