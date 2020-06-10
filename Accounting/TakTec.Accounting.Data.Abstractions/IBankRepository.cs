using EthioArt.Data.Abstraction;
using TakTec.Accounting.Entities;

namespace TakTec.Accounting.Data.Abstractions
{
    public interface IBankRepository:IGenericRepository<Bank>
    {
         Bank WithName(Bank bank);
    }
}