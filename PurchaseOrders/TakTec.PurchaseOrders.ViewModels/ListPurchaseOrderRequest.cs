using EthioArt.Backend.Models;
using EthioArt.Backend.Models.Requests;
using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.PurchaseOrders.Enumerations;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class ListPurchaseOrderRequest: PagedItemRequestBase, ISyncedObject  
    {       
        public String? FromDate { get; set; } = default!;
        public String? ToDate { get; set; } = default!;

        public bool IsExternalOrder { get; set; } = false;
        public string? LastUpdatedDate { get ; set ; } = default!;
        public ObjectStatusEnum ObjectStatus { get ; set ; } = default!;
    }
}
