

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
        public static List<VoucherModel> ToViewModel(this List<Voucher> vouchers) {
            return vouchers.Select(x => x.ToViewModel()).ToList();
        }

    }
}
