using EthioArt.Syncronization.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class NewPurchaseOrderModel: PurchaseOrderModel
    {
        public Boolean Self { get; set; } = default!; //if the request is made for the current user or on behalf of another user
        public String UserId { get; set; } = default!;        
    }
}
