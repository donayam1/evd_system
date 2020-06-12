using EthioArt.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakTec.Accounting.Data.Abstractions;
using TakTec.Accounting.Entities;
using Microsoft.EntityFrameworkCore;

namespace TakTec.Accounting.EntityFramework
{
    public class MoneyDepositRepository :
         GenericRepositoryBase<MoneyDeposit>,
        IMoneyDepositRepository
    {
        public override IQueryable<MoneyDeposit> LoadNavigationProperties(IQueryable<MoneyDeposit> items)
        {
            return items.Include(x => x.Bank);
        }
    }
}
