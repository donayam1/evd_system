using System;
using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
namespace TakTec.Data.Entities
{
    public class Operator: EntityBase
    {
       

         public Operator(string ownerId, ResourceTypes ownerType,string name,string USSDrechargeCode ) : base(ownerId, ownerType)
        {            
             Name = name;
             USSDRechargeCode=USSDrechargeCode;
         }
        
        public string Name { get; set; }
        public string USSDRechargeCode { get; set; }
        
    }
}
