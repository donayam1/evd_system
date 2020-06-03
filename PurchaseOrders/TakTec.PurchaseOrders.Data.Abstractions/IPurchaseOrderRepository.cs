using EthioArt.Data.Abstraction;
using System;
using TakTec.PurchaseOrders.Entities;

namespace TakTec.PurchaseOrders.Data.Abstractions
{
    public interface IPurchaseOrderRepository:
        IGenericRepository<PurchaseOrder>
    {
    }
}
