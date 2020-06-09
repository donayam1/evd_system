using EthioArt.Data.Abstraction;
using System;
using TakTec.Accounting.Entities;

namespace TakTec.Accounting.Data.Abstractions
{
    public interface IMoneyDepositRepository:
        IGenericRepository<MoneyDeposit>
    {
    }
}
