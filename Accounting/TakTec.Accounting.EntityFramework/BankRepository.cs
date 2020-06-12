using System;
using System.Collections.Generic;
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
            return items;
        }

        public Bank? WithName(string BankName)
        {
            return All().Where(x=>x.Name == BankName).FirstOrDefault();
        }
    }
}