
using EthioArt.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vouchers.Data.Abstractions;
using Vouchers.Data.Entities;

namespace Vouchers.Data.EntityFramework
{
    public class VouchersRepository : GenericRepositoryBase<Voucher>,
        IVouchersRepository
    {
        public override IQueryable<Voucher> LoadNavigationProperties(IQueryable<Voucher> items)
        {
            return items.Include(x=>x.Batch)
                        .Include(x=>x.VoucherStatuses);
        }


        public IQueryable<Voucher> GetFreeSystemVouchers(String? batchId = null, bool isApproved = true)
        {
            var items = this.All().Where(x => x.IsInSystemPool == true && x.Batch.IsAproved == isApproved);
            if (!String.IsNullOrWhiteSpace(batchId))
            {
                items = items.Where(x => x.BatchId == batchId);
            }
            return items;// this.All().Where(x => x.IsInSystemPool == true &&
                    //x.Batch.Id == batchId && x.Batch.IsAproved == isApproved); //GetFreeUserVouchers(RoleTypeConstants.RoleNameSupperAdmin, batchId, isApproved);
        }
        public IQueryable<Voucher> GetFreeSystemVouchers(float denomination, String? batchId = null, bool isApproved = true)
        {
            return this.GetFreeSystemVouchers(
                batchId, isApproved).Where(x => x.Batch.Denomination == denomination);
        }
        public IQueryable<Voucher> GetFreeSystemVouchers(float denomination, int quantity,
            String? batchId = null, bool isApproved = true)
        {
            return this.GetFreeSystemVouchers(
                denomination,  batchId, isApproved).Take(quantity);
        }
       
        public int CountSystemFreeVouchers(float denomination, int quantity,
            String? batchId = null, bool isApproved = true)
        {
            return GetFreeSystemVouchers( denomination, quantity,
                batchId, isApproved).Count();
        }



    }
}
