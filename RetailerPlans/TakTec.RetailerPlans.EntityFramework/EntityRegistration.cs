using TakTec.RetailerPlans.Entities;
using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;

namespace TakTec.RetailerPlans.EntityFramework
{
    public class EntityRegistration:IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            //RetailerPlan->Commission : one to many
            //RetailerPlan->Operator : many to one 
            modelbuilder.Entity<RetailerPlan>(x=>{
                x.HasKey(x=>x.Id);
                x.HasMany(c=>c.CommissionRates);
                x.HasOne(o=>o.Operator)
                    .WithMany()
                        .HasForeignKey(x=>x.OperatorId);

                x.ToTable(nameof(RetailerPlan)+"s");
            });

            modelbuilder.Entity<CommissionRate>(x=>{
                x.HasKey(x=>x.Id);
                x.HasOne(x => x.RetailerPlan)
                    .WithMany(y => y.CommissionRates)
                        .HasForeignKey(x => x.OwnerId);

                x.ToTable(nameof(CommissionRate)+"s");
            });
        }
        
    }
}