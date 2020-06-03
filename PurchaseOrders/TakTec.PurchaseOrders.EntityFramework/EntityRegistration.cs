using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using TakTec.PurchaseOrders.Entities;

namespace TakTec.PurchaseOrders.EntityFramework
{
    public class EntityRegistration : IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<PurchaseOrder>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasMany(x => x.OrderItems);
                x.ToTable(nameof(PurchaseOrder) + "s");
            });

            modelbuilder.Entity<PurchaseOrderItem>(x => {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.PurchaseOrder)
                    .WithMany(y=>y.OrderItems)
                    .HasForeignKey(x => x.OwnerId);
                x.ToTable(nameof(PurchaseOrderItem) + "s");
            });

        }
    }
}




