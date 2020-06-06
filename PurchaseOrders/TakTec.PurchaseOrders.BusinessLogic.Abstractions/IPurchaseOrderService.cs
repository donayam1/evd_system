using EthioArt.Backend.Models.Requests;
using System;
using System.Collections.Generic;
using TakTec.PurchaseOrders.ViewModels;

namespace TakTec.PurchaseOrders.BusinessLogic.Abstractions
{
    public interface IPurchaseOrderService
    {

        PurchaseOrderModel? CreatePurchaseOrder(NewPurchaseOrderModel request);
        List<PurchaseOrderModel> ListPuchaseOrders(PagedItemRequestBase request);
    }
}
