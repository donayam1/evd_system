using EthioArt.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakTec.PurchaseOrders.Data.Abstractions;
using TakTec.PurchaseOrders.Entities;
using Microsoft.EntityFrameworkCore;

namespace TakTec.PurchaseOrders.EntityFramework
{
    public class PurchaseOrderRepository : GenericRepositoryBase<PurchaseOrder>,
        IPurchaseOrderRepository
    {
        public override IQueryable<PurchaseOrder> LoadNavigationProperties(IQueryable<PurchaseOrder> items)
        {
            return items.Include(x => x.OrderItems);
        }
    }
}
