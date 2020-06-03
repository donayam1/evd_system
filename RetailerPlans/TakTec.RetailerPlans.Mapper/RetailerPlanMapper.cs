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
        public static RetailerPlanViewModel ToPlanViewModel(this RetailerPlan retailerPlan)
        {
            var retailerVM = new RetailerPlanViewModel()
            {
                Id = retailerPlan.Id,
                Code = retailerPlan.Code,
                Name = retailerPlan.Name,
                Description = retailerPlan.Description,
                CommissionRateType=retailerPlan.CommissionRateType,
                OperatorId = retailerPlan.OperatorId,
                RenewalAmount = retailerPlan.RenewalAmount,
                RenewalAmountChargingRate = retailerPlan.RenewalAmountChargingRate,
                JoinAmount = retailerPlan.JoiningAmount,
            };
            List<CommissionRate> commissions = retailerPlan.CommissionRates.ToList();
            retailerVM.CommissionRateViewModels=commissions.ToCommissionRateViewModelList();
            return retailerVM;
        }

        public static CommissionRateViewModel ToCommissionRateViewModel(this CommissionRate commissionRate)
        {
            var commissionrate = new CommissionRateViewModel()
            {
                Id = commissionRate.Id,
                Amount = commissionRate.Amount,
                Rate = commissionRate.Rate,
            };
            return commissionrate;
        }

        public static RetailerPlan ToPlanDomailModel(this RetailerPlanViewModel retailerPlanViewModel,List<CommissionRateViewModel> commissionRates)
        {
            //TODO owner id  =  group name of User , userId = CreatorUserId
            //not complete, to be mapped
            var retailerplan = new RetailerPlan("", ResourceTypes.GROUP,
                                retailerPlanViewModel.Code, retailerPlanViewModel.
                                Name, retailerPlanViewModel.CommissionRateType,
                                retailerPlanViewModel.OperatorId)
            {
                Description = retailerPlanViewModel.Description,
                RenewalAmountChargingRate = retailerPlanViewModel.RenewalAmountChargingRate,
                JoiningAmount = retailerPlanViewModel.JoinAmount,
                RenewalAmount=retailerPlanViewModel.RenewalAmount,
               // CommissionRates = commissionRates.
            };
            retailerplan.CommissionRates = commissionRates.ToCommissionRateList();
            return retailerplan;
        }

        public static CommissionRate ToCommissionRateDomainModel(this CommissionRateViewModel commissionRateViewModel)
        {
            CommissionRate commissionRate = new CommissionRate("",ResourceTypes.GROUP,
                                            commissionRateViewModel.Amount,
                                            commissionRateViewModel.Rate);
            return commissionRate;
        }
        

        public static NewRetailerPlanViewModel ToNewPlanViewModel(this RetailerPlan retailerPlan, string UI_Id)
        {
            NewRetailerPlanViewModel newRetailerPlanVM = (NewRetailerPlanViewModel)retailerPlan.ToPlanViewModel();
            newRetailerPlanVM.UI_Id = UI_Id;
            return newRetailerPlanVM;
        }

        public static List<RetailerPlanViewModel> ToPlanViewModelList(this List<RetailerPlan> retailerPlans)
        {
            var items = retailerPlans.Select(x=>x.ToPlanViewModel()).ToList();
            return items;
        }

        public static List<CommissionRateViewModel> ToCommissionRateViewModelList(this List<CommissionRate> commissionRates)
        {
            var items = commissionRates.Select(x=>x.ToCommissionRateViewModel()).ToList();
            return items;
        }

        public static List<CommissionRate> ToCommissionRateList(this List<CommissionRateViewModel> commissionRates)
        {
            var items = commissionRates.Select(x=>x.ToCommissionRateDomainModel()).ToList();
            return items;
        }
    }
}
