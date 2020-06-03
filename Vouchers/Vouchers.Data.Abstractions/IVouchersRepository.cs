using EthioArt.Data.Abstraction;
using System;
using System.Linq;
using Vouchers.Data.Entities;

namespace Vouchers.Data.Abstractions
{
    public interface IVouchersRepository: IGenericRepository<Voucher>
    {

        IQueryable<Voucher> GetFreeVouchers(float Denomination, int quantity);

    }
}
