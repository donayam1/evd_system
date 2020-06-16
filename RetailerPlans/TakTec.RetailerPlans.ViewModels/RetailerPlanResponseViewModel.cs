using EthioArt.Backend.Models.Responses;
namespace TakTec.RetailerPlans.ViewModels
{
    public class RetailerPlanResponseViewModel:ResponseBase
    {
        public RetailerPlanViewModel RetailerPlanViewModel { get; set; } = default!;
    }
}