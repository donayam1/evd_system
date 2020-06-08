using System.Collections.Generic;
using TakTec.RetailerPlans.Enumerations;
using System.ComponentModel.DataAnnotations;
using EthioArt.Data.Enumerations;

namespace TakTec.RetailerPlans.ViewModels
{
    public class RetailerPlanViewModel
    {
        public string? Id { get; set; }
        public int Code { get; set; } // TODO change this to String
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double JoinAmount { get; set; }
        public double RenewalAmount  { get; set; }
        public double  RenewalAmountChargingRate { get; set; }
        public CommissionRateType CommissionRateType { get; set; } = CommissionRateType.FLAT_COMMISSION;
        public List<CommissionRateViewModel> CommissionRateViewModels { get; set; } = new List<CommissionRateViewModel>();
        public int OperatorId { get; set; }
        public ObjectStatusEnum Status { get; set; } = ObjectStatusEnum.UNCHANGED;
       
    }
}