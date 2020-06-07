using EthioArt.Backend.Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.PurchaseOrders.Enumerations;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class ListPurchaseOrderRequest: PagedItemRequestBase 
    {
        PurchaseOrderStatus Status { get; set; } 
            = PurchaseOrderStatus.NEW; //: PuchaseOrderStatus  => this can be approved, weighting for approval, canceled
        public String FromDate { get; set; } = default!;
        public String ToDate { get; set; } = default!;

        public bool IsExternalOrder { get; set; } = false;

    }
}
