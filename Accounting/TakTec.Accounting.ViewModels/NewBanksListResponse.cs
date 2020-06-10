using System.Collections.Generic;
using EthioArt.Backend.Models.Responses;
namespace TakTec.Accounting.ViewModels
{
    public class NewBanksListResponse:ResponseBase
    {
        public List<NewBankViewModel> NewBanks { get; set; } = new List<NewBankViewModel>();
    }
}