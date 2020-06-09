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
    public class RetailerPlan : EntityBase
    {
        public RetailerPlan(string ownerId, ResourceTypes ownerType,
            int code,string name,CommissionRateType commissionRateType,int operatorId) 
                : base(ownerId, ownerType)
        {
            Name = name;
            Code = code;
            CommissionRateType = commissionRateType;
            OperatorId=operatorId;
        }

        [Required]
        public int Code { get; set; }
        public string Name { get; set; }
        public double RenewalAmountChargingRate { get; set; }
        public double JoiningAmount { get; set; }
        public double RenewalAmount { get; set; }
        public CommissionRateType CommissionRateType { get; set; }
        public int OperatorId { get; set; }
        public ICollection<CommissionRate> CommissionRates{ get; set; } = new List<CommissionRate>(); 


        [ForeignKey(nameof(OperatorId))]
        public virtual Operator? Operator { get; set; }
        


    }
}




