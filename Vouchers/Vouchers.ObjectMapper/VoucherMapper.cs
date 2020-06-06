

using Vouchers.Data.Entities;
using Vouchers.ViewModels;
using System.Linq;
using EthioArt.Extensions.DateTimeExtensions;
using System.Collections.Generic;

namespace Vouchers.ObjectMapper
{
   
    public static class VoucherMapper
    {
        public static VoucherModel ToViewModel(this Voucher voucher) {

            var cvs = voucher.VoucherStatuses.Where(x => x.IsCurrent == true).FirstOrDefault();
            if (cvs == null) {
                throw new System.Exception($"Voucher id={voucher.Id} has no current status.");
            }

            VoucherModel vm = new VoucherModel()
            {
                Id = voucher.Id,
                Denomination = voucher.Batch?.Denomination ?? 0.0f,
                PinNumber = 000,//voucher.PinNumber,
                SerialNumber = voucher.SerialNumber,
                VoucherStatus = voucher.VoucherStatuses.Where(x => x.IsCurrent == true).FirstOrDefault()?.Status ??
                Data.Enumerations.VoucherStatusTypes.Available,
                StopDate = voucher.Batch?.StopDate.ToSharedDateString() ?? ""
            };
            return vm;
        }
        public static VoucherModel ToSalesViewModel(this Voucher voucher) {
            var res = voucher.ToViewModel();
            res.PinNumber = voucher.PinNumber;
            return res;
        }
        public static List<VoucherModel> ToSalesViewModel(this List<Voucher> vouchers) {
            return vouchers.Select(x => x.ToSalesViewModel()).ToList();
        }

        public static List<VoucherModel> ToViewModel(this List<Voucher> vouchers) {
            return vouchers.Select(x => x.ToViewModel()).ToList();
        }

        public static VoucherBatchModel ToViewModel(this VoucherBatch batch) {
            VoucherBatchModel model = new VoucherBatchModel()
            {
                Id = batch.Id,
                Batch = batch.Batch,
                Denomination = batch.Denomination,
                PurchaserOrderNumber = batch.PurchaserOrderId,
                Quantity = batch.Quantity,
                StartSequence = batch.StartSequence + "",
                StopDate = batch.StopDate.ToSharedDateString()
            };
            return model;
        }

        public static List<VoucherBatchModel> ToViewModel(this List<VoucherBatch> batchs) {
            return batchs.Select(x => x.ToViewModel()).ToList();
        }


    }
}
