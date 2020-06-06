using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vouchers.ViewModels
{
    public class ActivateVoucherBatchRequest
    {
        [Required]
        public String Id { get; set; } = default!;
    }
}
