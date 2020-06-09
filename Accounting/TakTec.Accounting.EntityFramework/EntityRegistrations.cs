using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using TakTec.Accounting.Entities;

namespace TakTec.Accounting.EntityFramework
{
    public class EntityRegistrations : IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            //RetailerPlan->Commission : one to many
            //RetailerPlan->Operator : many to one 
            modelbuilder.Entity<AirTime>(x => {
                x.HasKey(x => x.Id);                
                x.ToTable(nameof(AirTime) + "s");
            });

           
            modelbuilder.Entity<AirTimeUpdate>(x => {
                x.HasKey(x => x.Id);
                x.ToTable(nameof(AirTimeUpdate) + "s");
            });
            modelbuilder.Entity<Bank>(x => {
                x.HasKey(x => x.Id);
                x.HasMany(x => x.BankAccounts);
                x.ToTable(nameof(Bank) + "s");
            });
            modelbuilder.Entity<BankAccount>(x => {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Bank)
                    .WithMany(x => x.BankAccounts)
                        .HasForeignKey(x => x.BankId);

                x.ToTable(nameof(BankAccount) + "s");
            });

            modelbuilder.Entity<MoneyDeposit>(x => {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Bank)
                    .WithMany(x => x.MoneyDeposits)
                        .HasForeignKey(x => x.BankId);
                x.HasMany(x => x.MoneyDepositRollbackRequests);
                x.ToTable(nameof(MoneyDeposit) + "s");
            });

            modelbuilder.Entity<MoneyDepositRollbackRequest>(x => {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.MoneyDeposit)
                    .WithMany(x => x.MoneyDepositRollbackRequests)
                    .HasForeignKey(x => x.MoneyDepositRequestId);
                    
                x.ToTable(nameof(MoneyDepositRollbackRequest) + "s");
            });
        }

    }
}
