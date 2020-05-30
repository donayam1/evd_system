using EthioArt.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vouchers.Data.Abstractions;
using Vouchers.Data.Entities;

namespace Vouchers.Data.EntityFramework
{
    public class VoucherBatchRepository : GenericRepositoryBase<VoucherBatch>,
        IVoucherBatchRepository
    {
        public override IQueryable<VoucherBatch> LoadNavigationProperties(IQueryable<VoucherBatch> items)
        {
            return items;
        }
    }
}
