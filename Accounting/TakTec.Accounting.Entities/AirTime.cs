using EthioArt.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Accounting.Entities
{
    public class AirTime:EntityBase 
    {
        public AirTime(String ownerId) : 
            base(ownerId,EthioArt.Data.Enumerations.ResourceTypes.GROUP) { 

        }

        public String MoneyDepositId { get; set; }
        public String RetailerPlanId { get; set; }
        public Decimal Amount { get; set; }
        public String IsCurrent { get; set; }

    }
}
