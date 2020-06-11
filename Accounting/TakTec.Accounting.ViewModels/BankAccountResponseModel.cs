using EthioArt.Backend.Models.Responses;
namespace TakTec.Accounting.ViewModels
{
    public class BankAccountResponseModel:ResponseBase
    {
        public BankAccountViewModel BankAccount{get;set;} = default!;
    }
}