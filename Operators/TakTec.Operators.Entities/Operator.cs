using System;
using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
namespace TakTec.Operators.Entities
{
    public class Operator : EntityBase
    {
        public Operator(string ownerId, ResourceTypes ownerType, 
            string name, string uSSDRechargeCode) : 
            base(ownerId, ownerType)
        {
            Name = name;
            this.USSDRechargeCode = uSSDRechargeCode;
        }

        public string Name { get; set; }
        public string USSDRechargeCode { get; set; }
    }

}
