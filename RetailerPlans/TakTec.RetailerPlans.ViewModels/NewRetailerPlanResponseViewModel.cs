using EthioArt.Backend.Models.Responses;

namespace TakTec.RetailerPlans.ViewModels
{
    public class NewRetailerPlanResponseViewModel:ResponseBase
    {
        public NewRetailerPlanViewModel NewRetailerPlanViewModel { get; set; } = default;
    }
}