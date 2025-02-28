﻿using System;
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
using TakTec.Core.Security;

namespace TakTec.RetailerPlans.Backend
{
    [Route("api/retailerPlans/[controller]")]
    [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName)]
    public class RetailerPlanController:ControllersBase
    {

        private readonly IRetailerPlanService _retailerPlanService;

        public RetailerPlanController(IUserMessageLogges userMessageLogges,IRetailerPlanService retailerPlanService)
                                    :base(userMessageLogges)
        {
            _retailerPlanService = retailerPlanService ?? 
                throw new ArgumentNullException(nameof(IRetailerPlanService));
        }

        //TODO authorization and identifying user

        [HttpGet(template:"list")]
        public IActionResult ListRetailerPlans([FromQuery]PagedItemRequestBase page)
        {
            if(ModelState.IsValid)
            {
                var planList = new RetailerPlanResponseListViewModel();
                var items = _retailerPlanService.ListRetailerPlans(page.Page,page.ItemsPerPage);//pass page object instead
                if(items == null)
                {
                    planList.Status = false;
                }
                else
                {
                    planList.Status=true;  
                    planList.RetailerPlans = items;
                }
                return SendResult(planList);
            }
            return BadRequest(ModelState);
        }

        [HttpPost(template:"create")]
        public IActionResult Create([FromBody] RetailerPlanViewModel retailerPlanViewModel)
        {             
            if(ModelState.IsValid)
            {
                var resp = new NewRetailerPlanResponseViewModel();
                var newRetailerPlan = _retailerPlanService.
                    CreateorUpdatePlan(retailerPlanViewModel);
                if(newRetailerPlan == null)
                {
                    resp.Status = false;
                }
                else
                {
                    resp.Status = true;
                    resp.NewRetailerPlan = (NewRetailerPlanViewModel?) newRetailerPlan;
                }

                return SendResult(resp);
            }
            return BadRequest(ModelState);
        }


        [HttpPost(template:"update")]
        public IActionResult Update([FromBody] RetailerPlanViewModel retailerPlanViewModel)
        {
            if(ModelState.IsValid)
            {
                var retailerPlan = new RetailerPlanResponseViewModel();
                var updatedPlan = _retailerPlanService.CreateorUpdatePlan(retailerPlanViewModel);
                if(updatedPlan == null)
                {
                    retailerPlan.Status = false;
                }
                else
                {
                    retailerPlan.Status = true;
                    retailerPlan.RetailerPlanViewModel = updatedPlan;
                }
                return SendResult(retailerPlan);
            }
            return BadRequest(ModelState);
        }


    }
}
