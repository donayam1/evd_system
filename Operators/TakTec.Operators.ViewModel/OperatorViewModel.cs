using System;
using EthioArt.Data.Enumerations;
using TakTec.Data.Entities;
namespace TakTec.Operators.ViewModel

{
    public class OperatorViewModel : Operator
    {
        public OperatorViewModel(string ownerId, ResourceTypes ownerType, string name, string USSDrechargeCode) : base(ownerId, ownerType, name, USSDrechargeCode)
        {
            this.OwnerId = ownerId;
            this.OwnerType = ownerType;
            this.Name = name;
            this.USSDRechargeCode = USSDrechargeCode;
        }
        public Status Status { get; set; }
    }
}
public enum Status{
    NEW = 0,
    UPDATED = 1
    //add other type of status
};