using EthioArt.Backend.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class ListPurchaseOrderResponse:ResponseBase 
    {
        public List<PurchaseOrderModel> PurcahseOrders { get; set; } 
            = new List<PurchaseOrderModel>();
    }
}
