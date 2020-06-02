using System;
using System.Linq;
using System.Collections.Generic;
using TakTec.RetailerPlans.Entities;
using TakTec.RetailerPlans.ViewModels;
using EthioArt.Data.Entities;
using EthioArt.Data.Enumerations;


namespace TakTec.RetailerPlans.Mapper
{
    public static class RetailerPlanMapper
    {
        public static RetailerPlanViewModel ToViewModel(this RetailerPlan retailerPlan)
        {
            var retailerVM = new RetailerPlanViewModel();
            return retailerVM;
        }

        public static RetailerPlan ToDomailModel(this RetailerPlanViewModel retailerPlanViewModel,CommissionRateViewModel commissionRateViewModel)
        {
            //TODO owner id  =  group name of User , userId = CreatorUserId
            //not complete, to be mapped
            var retailerplan = new RetailerPlan("",ResourceTypes.GROUP);
            return retailerplan;
        }

        public static NewRetailerPlanViewModel ToNewPlanViewModel(this RetailerPlan retailerPlan, string UI_Id)
        {
            //not complete, to be mapped
            NewRetailerPlanViewModel retailerPlanVM = new NewRetailerPlanViewModel();
            return retailerPlanVM;
        }

        public static List<RetailerPlanViewModel> ToViewModelList(this List<RetailerPlan> retailerPlans)
        {
            var items = retailerPlans.Select(x=>x.ToViewModel()).ToList();
            return items;
        }
    }
}
