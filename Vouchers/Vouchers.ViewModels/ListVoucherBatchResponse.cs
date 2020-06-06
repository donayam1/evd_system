using EthioArt.Backend.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vouchers.ViewModels
{
    public class ListVoucherBatchResponse:ResponseBase 
    {
        public List<VoucherBatchModel> VoucherBatches { get; set; } =
            new List<VoucherBatchModel>();
    }
}
