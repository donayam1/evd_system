using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TakTec.RetailerPlans.Entities
{
    public class UserPlan:EntityBase 
    {
        public UserPlan(String planId,String ownerId, 
            ResourceTypes ownerType = ResourceTypes.GROUP):
            base(ownerId,ownerType){           
            this.PlanId = planId;
        }

        public String PlanId { get; set; }
        public bool IsCurrent { get; set; } = true;



        public RetailerPlan? _retailerPlan;

        [ForeignKey(nameof(PlanId))]
        public RetailerPlan RetailerPlan
        {
            get
            {
                return _retailerPlan ?? throw new ArgumentNullException(nameof(_retailerPlan));
            }
            set
            {
                _retailerPlan = value;
            }
        }

    }
}
