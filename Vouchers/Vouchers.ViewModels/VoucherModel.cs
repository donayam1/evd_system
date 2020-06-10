using System;
using System.Collections.Generic;
using System.Text;
using Vouchers.Data.Enumerations;

namespace Vouchers.ViewModels
{
    public class VoucherModel
    {
        public String Id { get; set; } = default!;

        public int SerialNumber { get; set; }

        public int PinNumber { get; set; }

        public String StopDate { get; set; } = default!;

        public float Denomination { get; set; }

        public VoucherStatusTypes VoucherStatus { get; set; }
        public String BatchNumber { get; set; } = default!;
        public String CreatedDate { get; set; } = default!;

    }
}
