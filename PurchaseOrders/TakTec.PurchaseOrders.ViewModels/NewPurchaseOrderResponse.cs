using EthioArt.Backend.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class NewPurchaseOrderResponse:ResponseBase 
    {
        public NewPurchaseOrderResult NewPurchaseOrder { get; set; } = default!;
    }
}
