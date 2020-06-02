using System;
using System.Threading;
using System.Threading.Tasks;
using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Mvc;
using EthioArt.Backend.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using TakTec.RetailerPlans.Entities;
using TakTec.RetailerPlans.ViewModels;
using TakTec.RetailerPlans.BusinessLogic.Abstraction;


namespace TakTec.RetailerPlans.Backend
{
    [Route("api/retailerPlans/[controller]")]
    public class RetailerPlanController:ControllersBase
    {

        private readonly IRetailerPlanService _retailerPlanService;

        public RetailerPlanController(IUserMessageLogges userMessageLogges,IRetailerPlanService retailerPlanService)
                                    :base(userMessageLogges)
        {
            _retailerPlanService = retailerPlanService ?? 
                throw new ArgumentNullException(nameof(IRetailerPlanService));
        }

        [HttpGet(template:"list")]
        public IActionResult ListRetailerPlans([FromQuery]PagedItemRequestBase page)
        {
            var planList = new RetailerPlanResponseListViewModel();
            if(ModelState.IsValid)
            {
                var items = _retailerPlanService.ListRetailerPlans(page.Page,page.ItemsPerPage);//pass page object instead
                if(items == null)
                {
                    planList.Status = false;
                }
                else
                {
                    planList.Status=true;
                   // planList.RetailerPlans = items.;
                }
                return SendResult(planList);
            }
            return BadRequest(ModelState);
        }

        [HttpPost(template:"create")]
        public IActionResult Create([FromBody] RetailerPlanViewModel retailerPlanViewModel)
        {
            var newRetailerPlan = new NewRetailerPlanResponseViewModel();
            if(ModelState.IsValid)
            {
                return SendResult(newRetailerPlan);
            }
            return BadRequest(ModelState);
        }


        [HttpPost(template:"update")]
        public IActionResult Update([FromBody] RetailerPlanViewModel retailerPlanViewModel)
        {
            var retailerPlan = new RetailerPlanResponseViewModel();
            if(ModelState.IsValid)
            {
                return SendResult(retailerPlan);
            }
            return BadRequest(ModelState);
        }


    }
}
