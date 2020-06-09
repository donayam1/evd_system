using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TakTec.Accounting.ViewModels
{
    public class ApproveMoneyDepositRequest
    {
        [Required]
        public String Id { get; set; } = default!;
    }
}
