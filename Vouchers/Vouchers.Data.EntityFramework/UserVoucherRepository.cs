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

        private IQueryable<UserVoucher> GetFreeVouchers(String userRoleName) {
            return this.All().Where(x=>
                    x.Voucher.VoucherStatuses.Where(x => x.IsCurrent).FirstOrDefault().Status ==
                        Enumerations.VoucherStatusTypes.Available
                        &&x.Voucher.Batch.IsAproved == true
                        && x.OwnerId == userRoleName);
        }


        public IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName)
        {
            return GetFreeVouchers(userRoleName);
        }
        public IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName, float denomination)
        {
            return GetFreeUserVouchers(userRoleName).Where(x => x.Voucher.Batch.Denomination == denomination);
        }

        public IQueryable<UserVoucher> GetFreeUserVouchers(String userRoleName, float denomination, int quantity)
        {
            return this.GetFreeUserVouchers(userRoleName, denomination).Take(quantity);
        }

        public int CountUserFreeVouchers(String userRoleName, float denomination, int quantity) {
            return GetFreeUserVouchers(userRoleName, denomination, quantity).Count();
        }






        public IQueryable<UserVoucher> GetFreeSystemVouchers()
        {
            return GetFreeUserVouchers(RoleTypeConstants.RoleNameSupperAdmin);
        }
        public IQueryable<UserVoucher> GetFreeSystemVouchers(float denomination) {
            return this.GetFreeUserVouchers(RoleTypeConstants.RoleNameSupperAdmin, denomination);
        }
        public IQueryable<UserVoucher> GetFreeSystemVouchers(float denomination,int quantity)
        {
            return this.GetFreeUserVouchers(RoleTypeConstants.RoleNameSupperAdmin,denomination,quantity);
        }

        public int CountSystemFreeVouchers(String userRoleName, float denomination, int quantity) {
            return CountUserFreeVouchers(RoleTypeConstants.RoleNameSupperAdmin, denomination, quantity);
        }


    }
}
