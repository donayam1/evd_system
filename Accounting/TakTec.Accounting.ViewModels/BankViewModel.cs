using EthioArt.Data.Enumerations;
namespace TakTec.Accounting.ViewModels
{
    public class BankViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ObjectStatusEnum Status { get; set; }
    }
}