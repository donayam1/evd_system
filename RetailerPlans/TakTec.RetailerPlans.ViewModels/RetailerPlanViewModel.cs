using System.Collections.Generic;
using TakTec.RetailerPlans.Enumerations;

namespace TakTec.RetailerPlans.ViewModels
{
    public class RetailerPlanViewModel
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double JoinAmount { get; set; }
        public double RenewalAmount  { get; set; }
        public double  RenewalAmountChargingRate { get; set; }
        public CommissionRateType CommissionRateType { get; set; } 
        public List<CommissionRateViewModel> CommissionRateViewModels { get; set; }
        public int OperatorId { get; set; }
       
    }
}