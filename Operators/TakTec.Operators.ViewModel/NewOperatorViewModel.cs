using EthioArt.Data.Enumerations;

namespace TakTec.Operators.ViewModel
{
    public class NewOperatorViewModel : OperatorViewModel
    {
        public NewOperatorViewModel(string ownerId, ResourceTypes ownerType, string name, string USSDrechargeCode) : base(ownerId, ownerType, name, USSDrechargeCode)
        {
            this.OwnerId = ownerId;
            this.OwnerType= ownerType;
            this.Name = name;
            this.USSDRechargeCode=USSDrechargeCode;
        }
        public int UI_Id { get; set; }
    }
}