using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using Vouchers.Data.Entities;

namespace Vouchers.Data.EntityFramework
{
    public class EntityRegistration : IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Voucher>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasIndex(x => x.SerialNumber)
                    .IsUnique();
                x.HasIndex(x => x.PinNumber)
                    .IsUnique();
                //x.Property(x => x.Batch)
                //    .HasField("_batch");

                x.HasOne(x => x.Batch)
                    .WithMany(z => z.Vouchers)
                    .HasForeignKey(w => w.BatchId);
                x.HasMany(z => z.UserVouchers);
                x.ToTable(nameof(Voucher) + "s");
            });

            modelbuilder.Entity<UserVoucher>(x => {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Voucher)
                 .WithMany(x => x.UserVouchers)
                    .HasForeignKey(x => x.VoucherId);
                //x.Property(x => x.Voucher)
                //    .HasField("_voucher");

                //x.HasIndex(x => x.VoucherId)
                //    .IsUnique();
                x.ToTable(nameof(UserVoucher) + "s");
            });

            modelbuilder.Entity<VoucherBatch>(x => {
                x.HasKey(x => x.Id);
                x.HasIndex(x => x.Batch).IsUnique();
                x.HasMany(x => x.Vouchers);
                x.ToTable(nameof(VoucherBatch) + "s");
            });

            modelbuilder.Entity<VoucherMarkedForReTransmit>(x => {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Voucher)
                    .WithMany()
                    .HasForeignKey(x => x.VoucherId);
                //x.Property(x => x.Voucher)
                //    .HasField("_voucher");

                x.ToTable(nameof(VoucherMarkedForReTransmit));
            });

            modelbuilder.Entity<VoucherStatus>(x => {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Voucher)                
                .WithMany(z => z.VoucherStatuses)
                    .HasForeignKey(z => z.OwnerId);

                //x.Property(x => x.Voucher)
                //    .HasField("_voucher");

                x.ToTable(nameof(VoucherStatus)+"es");
            });


        }
    }
}




