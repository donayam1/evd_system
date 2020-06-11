using EthioArt.Backend.Models.Responses;
using System.Collections.Generic;

namespace TakTec.Accounting.ViewModels
{
    public class BankAccountListResponse:ResponseBase
    {
        public List<BankAccountViewModel> BankAccounts { get; set; } = new List<BankAccountViewModel>();
    }
}