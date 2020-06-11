using EthioArt.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TakTec.Accounting.Entities
{
    public class BankAccount:EntityBase 
    {
        public BankAccount(String bankId,String accountId,String ownerId) : 
            base(ownerId, EthioArt.Data.Enumerations.ResourceTypes.GROUP) {
            this.AccountId = accountId;
            this.BankId = bankId;
        }

        public String AccountId { get; set; }
        public String BankId { get; set; }


        private Bank? _bank;
        [ForeignKey(nameof(BankId))]
        public Bank Bank
        {
            get
            {
                return _bank ?? throw new InvalidOperationException($"{nameof(_bank)} is null.");
            }
            set
            { _bank = value; }
        }

    }
}
