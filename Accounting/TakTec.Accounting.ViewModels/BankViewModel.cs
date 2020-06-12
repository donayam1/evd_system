using EthioArt.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
namespace TakTec.Accounting.ViewModels
{
    public class BankViewModel
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        public ObjectStatusEnum Status { get; set; } = ObjectStatusEnum.UNCHANGED;
    }
}