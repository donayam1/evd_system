﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TakTec.RetailerPlans.ViewModels
{
    public class CommissionRateViewModel
    {
        [Required]
        public string Id { get; set; }
        public double Amount { get; set; }
        
        [Required]
        public double Rate { get; set; } = default;
    }
}
