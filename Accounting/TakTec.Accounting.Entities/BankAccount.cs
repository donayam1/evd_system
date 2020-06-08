using EthioArt.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Accounting.Entities
{
    public class BankAccount:EntityBase 
    {
        public BankAccount(String accountId,String ownerId) : 
            base(ownerId, EthioArt.Data.Enumerations.ResourceTypes.GROUP) {
            this.AccountId = accountId;
        }

        public String AccountId { get; set; }
        public String BankId { get; set; }

    }
}
