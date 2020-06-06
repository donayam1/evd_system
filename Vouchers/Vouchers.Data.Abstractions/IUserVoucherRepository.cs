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

        IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName, String? batchId = null, bool isApproved = true);
        IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName, float denomination, String? batchId = null, bool isApproved = true);
        IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName, float denomination, int quantity, String? batchId = null, bool isApproved = true);
        int CountUserFreeVouchers(String userRoleName, float denomination, String? batchId = null, bool isApproved = true);



        //IQueryable<UserVoucher> GetFreeSystemVouchers(String? batchId = null, bool isApproved = true);
        //IQueryable<UserVoucher> GetFreeSystemVouchers(float denomination, String? batchId = null, bool isApproved = true);
        //IQueryable<UserVoucher> GetFreeSystemVouchers(float denomination, int quantity, String? batchId = null, bool isApproved = true);
        //int CountSystemFreeVouchers(float denomination, int quantity, String? batchId = null, bool isApproved = true);


    }
}
