using System.Collections.Generic;
using TakTec.RetailerPlans.Enumerations;
using System.ComponentModel.DataAnnotations;
using EthioArt.Data.Enumerations;

namespace TakTec.RetailerPlans.ViewModels
{
    public class RetailerPlanViewModel
    {
        [Required]
        public string Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double JoinAmount { get; set; }
        [Required]
        public double RenewalAmount  { get; set; }
        [Required]
        public double  RenewalAmountChargingRate { get; set; }
        [Required]
        public CommissionRateType CommissionRateType { get; set; } 
        public List<CommissionRateViewModel> CommissionRateViewModels { get; set; } = default;
        public int OperatorId { get; set; }
        public ObjectStatusEnum Status { get; set; }
       
    }
}