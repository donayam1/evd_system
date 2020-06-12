using EthioArt.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
namespace TakTec.Accounting.ViewModels
{
    public class BankAccountViewModel
    {
        public string? Id {get;set;}
        [Required]
        public string AccountNumber { get; set; } = default!;
        public ObjectStatusEnum Status { get; set; } = ObjectStatusEnum.UNCHANGED;

        [Required]
        public string BankId { get; set; } = default!;

        [Required]
        public string UserId { get; set; } = default!;

    }
}