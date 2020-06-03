using System.Collections.Generic;
using EthioArt.Backend.Models.Responses;

namespace TakTec.RetailerPlans.ViewModels
{
    public class RetailerPlanResponseListViewModel:ResponseBase
    {
        public List<RetailerPlanViewModel> RetailerPlans = new List<RetailerPlanViewModel>();
    }
}