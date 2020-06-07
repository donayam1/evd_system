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
        public String? UserId { get; set; } = default!;
        /// <summary>
        /// Only system admin is allowed to make an external request 
        /// </summary>
        public Boolean IsExternalOrder { get; set; } = default!;
    }

    public class InternalPurchaseOrderRequest : NewPurchaseOrderModel {
        

        /// <summary>
        /// perform the order form the given batch
        /// </summary>
        public String? BatchId { get; set; } = default!;

        /// <summary>
        /// Only buy this voucher 
        /// </summary>
        public bool IsApproved { get; set; } = true;

    }

}
