using System.Net.Mime;
using System;
using Messages.Logging.Extensions;
using TakTec.RetailerPlans.Abstractions;
using ExtCore.Data.Abstractions;
using Microsoft.Extensions.Logging;
using TakTec.RetailerPlans.BusinessLogic.Abstraction;
using TakTec.RetailerPlans.Entities;
using System.Collections.Generic;
using TakTec.RetailerPlans.ViewModels;
using TakTec.RetailerPlans.Mapper;
using TakTec.Operators.Abstractions;
using TakTec.RetailerPlans.Enumerations;
using EthioArt.Data.Enumerations;
using System.Linq;

namespace TakTec.RetailerPlans.BusinessLogic
{
    public class RetailerPlanService : IRetailerPlanService
    {

        private readonly IRetailerPlanRepository _retailerPlanRepository;
        private readonly ILogger<IRetailerPlanService> _logger;
        private readonly IStorage _storage;
        private readonly IOperatorRepository _operatorRepository; 


        public RetailerPlanService(IStorage storage,ILogger<IRetailerPlanService> logger)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _retailerPlanRepository = _storage.GetRepository<IRetailerPlanRepository>()??
                                     throw new ArgumentNullException(nameof(IRetailerPlanRepository));
            _operatorRepository = _storage.GetRepository<IOperatorRepository>()??
                                     throw new ArgumentNullException(nameof(IOperatorRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public RetailerPlanViewModel CreateorUpdatePlan(RetailerPlanViewModel retailerPlanModel)
        {
            //TODO create and update
                
             RetailerPlan retPlan = retailerPlanModel.ToPlanDomailModel(retailerPlanModel.CommissionRateViewModels);
             if(!ValidatePlan(retPlan))
             {
                _logger.AddUserError("Invalid request");
             }
             
            RetailerPlan plan1;
             
            //create plan
            if(retailerPlanModel.Status == ObjectStatusEnum.NEW)
            {
                var rp = _retailerPlanRepository.All()
                            .Where(x=>x.Code == retPlan.Code || x.Name == retPlan.Name)
                            .FirstOrDefault();
                if(rp != null){
                    _logger.AddUserError("Plan already exists!");
                    plan1 = null;
                }
                plan1 = CreateNewPlan(retPlan);
            }


            //update plan
            var retailerPlan = _retailerPlanRepository.WithKey(retailerPlanModel.Id);
            if(retPlan == null)
            {
                _logger.AddUserError("Plan does not exist!!");
                return null;
            }

            plan1 = UpdatePlan(retPlan);

            

            if (plan1 != null)
            {
                try
                {
                    _storage.Save();
                }
                catch (Exception e)
                {
                    _logger.LogError(e.InnerException, e.Message);
                    _logger.AddUserError("Unknowen error. Please contact administrator.");
                    return null;
                }
            }
            return plan1.ToPlanViewModel();

        }

        private bool ValidatePlan(RetailerPlan plan)
        {
            bool isValidOperator = _operatorRepository.Exists(plan.Operator.Id);

            bool isValidJoinAmount = plan.JoiningAmount >= 0;
            bool isValidRenwalAMount = plan.RenewalAmount >= 0;
            bool isValidCommissionRate = plan.CommissionRateType == CommissionRateType.FLAT_COMMISSION ||
                                         plan.CommissionRateType == CommissionRateType.PER_RECHARGE_COMMISSION;   


            // add other validation criteria
            if(isValidOperator && isValidJoinAmount && isValidRenwalAMount && isValidCommissionRate)
            {
                return true;
            }
            return false;
        }

         private RetailerPlan CreateNewPlan(RetailerPlan newPlan)
         {
            _retailerPlanRepository.Create(newPlan);
            return newPlan;
        }

         private RetailerPlan UpdatePlan (RetailerPlan retailerPlan)
        {
            //find other plans with same name or code
            var p = _retailerPlanRepository.WithCodeorWithName(retailerPlan);
                            
            if(p != null)
            {
                _logger.AddUserError("Redundant plan");
                return null;
            }

            var result = _retailerPlanRepository.WithKey(retailerPlan.Id);
            result.Name = retailerPlan.Name;
            result.Code = retailerPlan.Code;
            result.Description = retailerPlan.Description;
            
            _retailerPlanRepository.Edit(result);
            return result;
        }

        public List<RetailerPlanViewModel> ListRetailerPlans(int pageNo, int ItemsPerPage)
        {
            var plans = _retailerPlanRepository.GetCustomFilters(pageNo,ItemsPerPage).Items.ToList();
            if(plans ==null){
                _logger.AddUserError("There is no Plan in database!");
                return null;
            }
           
            string msg = "There are " + plans.Count + " plans";
            _logger.AddUserMesage(msg);
            return plans.ToPlanViewModelList();
            

           
        }

       
    }
}
