using EthioArt.Backend.Models.Responses;

namespace TakTec.Accounting.ViewModels
{
    public class NewBankAccountResponse:ResponseBase
    {
        public NewBankAccountViewModel NewBankAccount { get; set; } = default!;
    }
}