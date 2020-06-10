using System.Collections.Generic;
using EthioArt.Backend.Models.Responses;
namespace TakTec.Accounting.ViewModels
{
    public class NewBankResponse:ResponseBase
    {
        List<NewBankResponse> NewBanks{get;set;} = new List<NewBankResponse>();
    }
}