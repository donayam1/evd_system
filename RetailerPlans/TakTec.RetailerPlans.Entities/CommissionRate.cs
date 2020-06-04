using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
using TakTec.Operators.Entities;
using System.Collections.Generic;
using TakTec.RetailerPlans.Enumerations;


namespace TakTec.RetailerPlans.Entities
{
    public class CommissionRate:EntityBase
    {
         public CommissionRate(string ownerId, ResourceTypes ownerType,double amount,double rate) 
                : base(ownerId, ownerType)
        {
            Amount = amount;
            Rate = rate;
        }
        public double Amount { get; set; } = 0;
        
        public double Rate { get; set; }=default;
    }
}

