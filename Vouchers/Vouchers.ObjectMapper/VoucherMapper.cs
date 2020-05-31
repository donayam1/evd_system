

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
            VoucherModel vm = new VoucherModel()
            {
                Id = voucher.Id,
                Denomination = voucher.Batch?.Denomination ??0.0f,
                PinNumber = voucher.PinNumber,
                SerialNumber = voucher.SerialNumber,
                VoucherStatus = voucher.VoucherStatuses.Where(x => x.IsCurrent == true).FirstOrDefault()?.Status??
                Data.Enumerations.VoucherStatusTypes.Available,
                StopDate = voucher.Batch?.StopDate.ToSharedDateString()??""
            };
            return vm;
        }
        public static List<VoucherModel> ToViewModel(this List<Voucher> vouchers) {
            return vouchers.Select(x => x.ToViewModel()).ToList();
        }

    }
}
