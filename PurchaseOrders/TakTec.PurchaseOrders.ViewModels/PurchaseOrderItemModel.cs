using EthioArt.Syncronization.Abstractions;
using System;
using Vouchers.Shared.ViewModels;
//using Vouchers.ViewModels;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class PurchaseOrderItemModel: VoucherTransferRequestItem, ILocable
    {
        public String? Id { get; set; }
        //public float Denomination { get; set; }
        //public int Quantity { get; set; }
        public String? OwnerId { get; set; } = default!;

        public string GetLockId()
        {
            return (int)Denomination + "";
        }
    }
}
