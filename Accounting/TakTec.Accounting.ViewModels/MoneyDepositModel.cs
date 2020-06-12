using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Accounting.ViewModels
{
    public class MoneyDepositModel
    {
        //public String FromUserRoleName { get; set; }
        public String ForUserId { get; set; } = default!;
        public decimal Amount { get; set; }
        public String BankId { get; set; } = default!;
        public String ReferanceNumber { get; set; } = default!;
        public Boolean IsCheque { get; set; } = false;
    }
}
