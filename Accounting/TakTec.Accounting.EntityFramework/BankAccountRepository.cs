using System;
using System.Collections.Generic;
using System.Linq;
using EthioArt.Data.EntityFramework;
using ExtCore.Data.Abstractions;
using TakTec.Accounting.Data.Abstractions;
using TakTec.Accounting.Entities;
namespace TakTec.Accounting.EntityFramework
{
    public class BankAccountRepository : GenericRepositoryBase<BankAccount>, IBankAccountRepository
    {
        public override IQueryable<BankAccount> LoadNavigationProperties(IQueryable<BankAccount> items)
        {
            throw new NotImplementedException();
        }

        public BankAccount? WithAccountNumber(string accountNumber)
        {
            return All().Where(x=>x.AccountNumber == accountNumber).FirstOrDefault();
        }
    }
}