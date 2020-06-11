using EthioArt.Data.Abstraction;
using TakTec.Accounting.Entities;

namespace TakTec.Accounting.Data.Abstractions
{
    public interface IBankAccountRepository:IGenericRepository<BankAccount>
    {
         BankAccount? WithAccountNumber(string accountNumber);
    }
}