using System;
using System.Collections.Generic;
using TakTec.RetailerPlans.Entities;
using EthioArt.Backend.Models;
using TakTec.RetailerPlans.ViewModels;

namespace TakTec.RetailerPlans.BusinessLogic.Abstraction
{
    public interface IRetailerPlanService
    {
        RetailerPlanViewModel? CreateorUpdatePlan(RetailerPlanViewModel retailerPlanModel);
       // RetailerPlanViewModel? UpdateRetailerPlan(RetailerPlan retailerPlan);
        
        List<RetailerPlanViewModel> ListRetailerPlans(int pageNo,int ItemsPerPage);
        Boolean AddUserToPlan(String userRole, String planId);
    }
}
