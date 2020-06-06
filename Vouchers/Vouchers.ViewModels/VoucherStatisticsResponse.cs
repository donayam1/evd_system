using EthioArt.Backend.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vouchers.ViewModels
{
    public class VoucherStatisticsResponse:ResponseBase 
    {
        public List<VoucherStatistics> VoucherStatistics { get; set; } = new List<VoucherStatistics>();
    }
}
