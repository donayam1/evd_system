using System.Collections.Generic;
using TakTec.RetailerPlans.Enumerations;
using System.ComponentModel.DataAnnotations;
using EthioArt.Data.Enumerations;
using System;

namespace TakTec.RetailerPlans.ViewModels
{
    public class RetailerPlanViewModel
    {
        public string? Id { get; set; }
        public String? Code { get; set; } // TODO change this to String
        public string Name { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public double JoinAmount { get; set; }
        public double RenewalAmount  { get; set; }
        public double  RenewalAmountChargingRate { get; set; }
        public CommissionRateType CommissionRateType { get; set; } = CommissionRateType.FLAT_COMMISSION;
        public List<CommissionRateViewModel> CommissionRates { get; set; } = new List<CommissionRateViewModel>();
        
        [Required]
        public String OperatorId { get; set; } = default!;
        public ObjectStatusEnum Status { get; set; } = ObjectStatusEnum.UNCHANGED;
       
    }
}