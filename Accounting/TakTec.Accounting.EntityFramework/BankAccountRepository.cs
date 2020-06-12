using System;
using System.Collections.Generic;
using System.Linq;
using EthioArt.Data.EntityFramework;
using ExtCore.Data.Abstractions;
using TakTec.Accounting.Data.Abstractions;
using TakTec.Accounting.Entities;
using Microsoft.EntityFrameworkCore;

namespace TakTec.Accounting.EntityFramework

{
    public class BankAccountRepository : GenericRepositoryBase<BankAccount>, 
        IBankAccountRepository
    {
        public override IQueryable<BankAccount> LoadNavigationProperties(IQueryable<BankAccount> items)
        {
            return items.Include(x=>x.Bank);
        }

        public BankAccount? WithAccountNumber(string accountNumber,String bankId)
        {
            return All().Where(x=>x.AccountNumber == accountNumber && x.BankId == bankId).FirstOrDefault();
        }
    }
}