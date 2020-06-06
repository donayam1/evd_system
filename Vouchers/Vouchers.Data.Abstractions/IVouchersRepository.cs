using EthioArt.Data.Abstraction;
using System;
using System.Linq;
using Vouchers.Data.Entities;

namespace Vouchers.Data.Abstractions
{
    public interface IVouchersRepository: IGenericRepository<Voucher>
    {
        IQueryable<Voucher> GetFreeSystemVouchers(String? batchId = null, bool isApproved = true);
        IQueryable<Voucher> GetFreeSystemVouchers(float denomination, String? batchId = null, bool isApproved = true);
        IQueryable<Voucher> GetFreeSystemVouchers(float denomination, int quantity,
            String? batchId = null, bool isApproved = true);
        int CountSystemFreeVouchers(float denomination, int quantity,
            String? batchId = null, bool isApproved = true);
    }
}
