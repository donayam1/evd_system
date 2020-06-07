using EthioArt.Backend.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vouchers.ViewModels
{
    public class CheckOutVoucherResponse :ResponseBase 
    {
        public VoucherModel? Voucher { get; set; } = default!;
    }
}
