using System;
using System.Linq;
using EthioArt.Data.EntityFramework;
using ExtCore.Data.Abstractions;
using TakTec.Accounting.Data.Abstractions;
using TakTec.Accounting.Entities;

namespace TakTec.Accounting.EntityFramework
{
    public class BankRepository : GenericRepositoryBase<Bank>, IBankRepository
    {
        public override IQueryable<Bank> LoadNavigationProperties(IQueryable<Bank> items)
        {
            throw new NotImplementedException();
        }

        public Bank WithName(Bank bank)
        {
            return All().Where(x=>x.Name == bank.Name).FirstOrDefault();
        }
    }
}