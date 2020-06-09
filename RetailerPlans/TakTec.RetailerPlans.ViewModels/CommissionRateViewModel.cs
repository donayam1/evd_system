using System;
using System.ComponentModel.DataAnnotations;

namespace TakTec.RetailerPlans.ViewModels
{
    public class CommissionRateViewModel
    {
        [Required]
        public string Id { get; set; } = default!;
        public decimal Amount { get; set; }
        
        [Required]
        public double Rate { get; set; } = default;
    }
}
