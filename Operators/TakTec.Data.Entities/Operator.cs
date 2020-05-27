using System;
using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
namespace TakTec.Data.Entities
{
    public class Operator: EntityBase
    {
        public Operator(string ownerId, ResourceTypes ownerType) : base(ownerId, ownerType)
        {
            this.OwnerId = ownerId;
            this.OwnerType=ownerType;
        }
        public string Name { get; set; }
        public string USSDRechargeCode { get; set; }
        
    }
}
