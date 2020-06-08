using EthioArt.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Accounting.Entities
{
    public class MoneyDepositRollbackRequeste: EntityBase 
    {
        public MoneyDepositRollbackRequeste() : 
            base("",EthioArt.Data.Enumerations.ResourceTypes.GROUP) { 
        
        }

        public String MoneyDepositRequestId { get; set; }
    }
}
