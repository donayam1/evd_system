using EthioArt.Backend.Models.Responses;
using System;
using System.Collections.Generic;

namespace TakTec.Accounting.ViewModels
{
    public class BanksListResponseViewModel:ResponseBase
    {
        public List<BankViewModel> Banks { get; set; } = new List<BankViewModel>();
    }
}