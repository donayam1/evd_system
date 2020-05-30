using EthioArt.Data.Abstraction;
using System;
using Vouchers.Data.Entities;

namespace Vouchers.Data.Abstractions
{
    public interface IVouchersRepository: IGenericRepository<Voucher>
    {
    }
}
