using System;
using System.Collections.Generic;
using System.Text;
using Vouchers.Data.Entities;
using Vouchers.ViewModels;

namespace TakTec.PurchaseOrders.ViewModels
{
    public class CreatePurchaseOrdreResult
    {
        public NewPurchaseOrderResult? PurchaseOrder { get; set; } = default!;
        public List<Voucher> Vouchers { get; set; } = new List<Voucher>();
    }

    public class PeekVoucherResult {
        public NewPurchaseOrderResult? PurchaseOrder { get; set; } = default!;
        public List<VoucherModel> Vouchers { get; set; } = new List<VoucherModel>();
    }

}
