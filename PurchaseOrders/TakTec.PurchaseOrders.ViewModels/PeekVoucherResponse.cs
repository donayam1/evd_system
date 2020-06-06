using EthioArt.Backend.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using Vouchers.ViewModels;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class PeekVoucherResponse:ResponseBase 
    {
        public PurchaseOrderModel? PurchaseOrder { get; set; } = default!;
        public VoucherModel? Voucher { get; set; } = default!;
    }
}
