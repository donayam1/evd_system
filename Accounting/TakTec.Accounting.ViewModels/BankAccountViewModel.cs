using EthioArt.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
namespace TakTec.Accounting.ViewModels
{
    public class BankAccountViewModel
    {
        [Required]
        public string Id {get;set;}
        [Required]
        public int AccountNumber { get; set; }
        public ObjectStatusEnum Status { get; set; }
        [Required]
        public string BankId {get;set;}
        [Required]
        public string UserId{get;set;}

    }
}