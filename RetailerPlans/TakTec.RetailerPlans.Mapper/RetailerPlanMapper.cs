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
            retailerVM.CommissionRates=retailerPlan.CommissionRates.ToList().ToCommissionRateViewModelList();
            return retailerVM;
        }
        public static RetailerPlanViewModel ToNewPlanViewModel(this RetailerPlan retailerPlan,String? UI_Id)
        {
            var retailerVM = new NewRetailerPlanViewModel()
            {
                Id = retailerPlan.Id,
                Code = retailerPlan.Code,
                Name = retailerPlan.Name,
                Description = retailerPlan.Description,
                CommissionRateType = retailerPlan.CommissionRateType,
                OperatorId = retailerPlan.OperatorId,
                RenewalAmount = retailerPlan.RenewalAmount,
                RenewalAmountChargingRate = retailerPlan.RenewalAmountChargingRate,
                JoinAmount = retailerPlan.JoiningAmount,
                UI_Id = UI_Id
            };
            retailerVM.CommissionRates = retailerPlan.CommissionRates.ToList().ToCommissionRateViewModelList();
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

        public static RetailerPlan ToPlanDomailModel(this RetailerPlanViewModel retailerPlanViewModel, String ownerId)//,List<CommissionRateViewModel> commissionRates)
        {
            //TODO owner id  =  group name of User , userId = CreatorUserId
            var retailerplan = new RetailerPlan(ownerId,
                                 retailerPlanViewModel.Name, retailerPlanViewModel.CommissionRateType,
                                retailerPlanViewModel.OperatorId)
            {
                Description = retailerPlanViewModel.Description,
                RenewalAmountChargingRate = retailerPlanViewModel.RenewalAmountChargingRate,
                JoiningAmount = retailerPlanViewModel.JoinAmount,
                RenewalAmount=retailerPlanViewModel.RenewalAmount,
               // CommissionRates = commissionRates.
            };
            retailerplan.CommissionRates = retailerPlanViewModel.CommissionRates.ToCommissionRateList(retailerplan.Id);
            return retailerplan;
        }

        public static CommissionRate ToCommissionRateDomainModel(this CommissionRateViewModel commissionRateViewModel,String ownerId)
        {
            CommissionRate commissionRate = new CommissionRate(ownerId,
                                            commissionRateViewModel.Amount,
                                            commissionRateViewModel.Rate);
            return commissionRate;
        }
        

        //public static NewRetailerPlanViewModel ToNewPlanViewModel(this RetailerPlan retailerPlan, string? UI_Id)
        //{
        //    NewRetailerPlanViewModel newRetailerPlanVM = retailerPlan.ToNewPlanViewModel();
        //    newRetailerPlanVM.UI_Id = UI_Id;
        //    return newRetailerPlanVM;
        //}

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

        public static List<CommissionRate> ToCommissionRateList(this List<CommissionRateViewModel> commissionRates,String ownerId)
        {
            var items = commissionRates.Select(x=>x.ToCommissionRateDomainModel(ownerId)).ToList();
            return items;
        }
    }
}
