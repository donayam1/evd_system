using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TakTec.Accounting.ViewModels
{
    public class ApproveMoneyDepositRollabckRequest
    {

        [Required]
        public String Id { get; set; } = default!;

    }
}
