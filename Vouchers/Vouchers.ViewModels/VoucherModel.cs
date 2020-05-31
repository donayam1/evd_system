using System;
using System.Collections.Generic;
using System.Text;
using Vouchers.Data.Enumerations;

namespace Vouchers.ViewModels
{
    public class VoucherModel
    {
        public String Id { get; set; }

        public String SerialNumber { get; set; }

        public String PinNumber { get; set; }

        public String StopDate { get; set; }

        public String Denomination { get; set; }

        public VoucherStatusTypes VoucherStatus { get; set; }


    }
}
