using EthioArt.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TakTec.Accounting.Entities
{
    public class MoneyDepositRollbackRequest: EntityBase 
    {
        public MoneyDepositRollbackRequest(String moneyDepositRequestId) : 
            base("",EthioArt.Data.Enumerations.ResourceTypes.GROUP) {
            this.MoneyDepositRequestId = moneyDepositRequestId;
        }

        public String MoneyDepositRequestId { get; set; }

        [ForeignKey(nameof(MoneyDepositRequestId))]
        public MoneyDeposit? MoneyDeposit { get; set; } = default!;
    }
}
