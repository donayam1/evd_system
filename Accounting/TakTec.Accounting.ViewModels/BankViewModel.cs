using EthioArt.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
namespace TakTec.Accounting.ViewModels
{
    public class BankViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ObjectStatusEnum Status { get; set; }
    }
}