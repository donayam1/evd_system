using EthioArt.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vouchers.Data.Entities;

namespace Vouchers.Data.Abstractions
{
    public interface IUserVoucherRepository:
         IGenericRepository<UserVoucher>
    {

        IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName);
        IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName, float denomination);
        IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName, float denomination, int quantity);
        int CountUserFreeVouchers(String userRoleName, float denomination, int quantity);



        IQueryable<UserVoucher> GetFreeSystemVouchers();
        IQueryable<UserVoucher> GetFreeSystemVouchers(float denomination);
        IQueryable<UserVoucher> GetFreeSystemVouchers(float denomination, int quantity);
        int CountSystemFreeVouchers(String userRoleName, float denomination, int quantity);


    }
}
