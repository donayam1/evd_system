﻿using EthioArt.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Accounting.Entities
{
    public class Bank:EntityBase 
    {
        public Bank(String name) : 
            base("",EthioArt.Data.Enumerations.ResourceTypes.SITE) {
            this.Name = name;
        }
        public String Name { get; set; }
        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public List<MoneyDeposit> MoneyDeposits { get; set; } = new List<MoneyDeposit>();
    }
}
