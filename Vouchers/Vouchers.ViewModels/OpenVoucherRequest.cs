using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vouchers.ViewModels
{
    public class OpenVoucherRequest
    {
        [Required]
        public String VoucherId { get; set; } = default!;
    }
}
