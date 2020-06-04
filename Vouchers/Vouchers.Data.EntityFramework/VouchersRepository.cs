
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
        
    }
}
