using EthioArt.Data.Abstraction;
using System;
using TakTec.Accounting.Entities;

namespace TakTec.Accounting.Data.Abstractions
{
    public interface IBankAccountRepository:IGenericRepository<BankAccount>
    {
         BankAccount? WithAccountNumber(string accountNumber, String bankId);
    }
}