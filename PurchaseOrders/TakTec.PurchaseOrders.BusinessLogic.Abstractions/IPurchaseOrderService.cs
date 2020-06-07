using EthioArt.Backend.Models.Requests;
using System;
using System.Collections.Generic;
using TakTec.PurchaseOrders.ViewModels;
using Vouchers.ViewModels;

namespace TakTec.PurchaseOrders.BusinessLogic.Abstractions
{
    public interface IPurchaseOrderService
    {
        CreatePurchaseOrdreResult? CreatePurchaseOrder(NewPurchaseOrderModel request);
        List<PurchaseOrderModel> ListPuchaseOrders(ListPurchaseOrderRequest request);
        PeekVoucherResult? PeekVoucher(PeekVoucherRequest request);

    }
}
