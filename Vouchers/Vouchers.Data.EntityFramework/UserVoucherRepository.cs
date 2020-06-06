using EthioArt.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vouchers.Data.Abstractions;
using Vouchers.Data.Entities;
using Microsoft.EntityFrameworkCore;
using TakTec.Users.Constants;

namespace Vouchers.Data.EntityFramework
{
    public class UserVoucherRepository : GenericRepositoryBase<UserVoucher>,
        IUserVoucherRepository
    {
        public override IQueryable<UserVoucher> LoadNavigationProperties(IQueryable<UserVoucher> items)
        {
            return items.Include(x=>x.Voucher)
                .ThenInclude(x=>x.VoucherStatuses)
                .Include(x => x.Voucher).ThenInclude(x=>x.Batch);
        }

        private IQueryable<UserVoucher> GetFreeVouchers(String userRoleName,
            String? batchId = null,bool isApproved = true) {

            var items = this.All().Where(x=>
                    x.Voucher.VoucherStatuses.Where(x => x.IsCurrent).FirstOrDefault().Status ==
                        Enumerations.VoucherStatusTypes.Available
                        &&x.Voucher.Batch.IsAproved == isApproved
                        && x.OwnerId == userRoleName);

            if (!String.IsNullOrWhiteSpace(batchId))  
            {
                items = items.Where(x => x.Voucher.BatchId == batchId);
            }
            
            return items;
        }


        public IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName,
            String? batchId = null, bool isApproved = true)
        {
            return GetFreeVouchers(userRoleName,batchId,isApproved);
        }
        public IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName, float denomination,
            String? batchId = null, bool isApproved = true)
        {
            return GetFreeUserVouchers(userRoleName,batchId,isApproved).Where(x => x.Voucher.Batch.Denomination == denomination);
        }

        public IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName, float denomination,
            int quantity,String? batchId = null, bool isApproved = true)
        {
            return this.GetFreeUserVouchers(userRoleName, denomination,batchId,isApproved).Take(quantity);
        }

        public int CountUserFreeVouchers(String userRoleName, float denomination, 
            String? batchId = null, bool isApproved = true) {
            return GetFreeUserVouchers(userRoleName, denomination, batchId,isApproved).Count();
        }






        //public IQueryable<UserVoucher> GetFreeSystemVouchers(String? batchId = null, bool isApproved = true)
        //{
        //    return GetFreeUserVouchers(RoleTypeConstants.RoleNameSupperAdmin,batchId,isApproved);
        //}
        //public IQueryable<UserVoucher> GetFreeSystemVouchers(float denomination, String? batchId = null, bool isApproved = true) {
        //    return this.GetFreeUserVouchers(RoleTypeConstants.RoleNameSupperAdmin, denomination,
        //        batchId,isApproved);
        //}
        //public IQueryable<UserVoucher> GetFreeSystemVouchers(float denomination,int quantity,
        //    String? batchId = null, bool isApproved = true)
        //{
        //    return this.GetFreeUserVouchers(RoleTypeConstants.RoleNameSupperAdmin,
        //        denomination,quantity,batchId,isApproved);
        //}

        //public int CountSystemFreeVouchers(float denomination, int quantity,
        //    String? batchId = null, bool isApproved = true) {
        //    return CountUserFreeVouchers(RoleTypeConstants.RoleNameSupperAdmin, denomination, quantity,
        //        batchId, isApproved);
        //}


    }
}
