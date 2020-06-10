using EthioArt.Backend.Models.Responses;

namespace TakTec.Accounting.ViewModels
{
    public class BankResponseViewModel:ResponseBase
    {
        public BankViewModel Bank { get; set; } = default!;
    }
}