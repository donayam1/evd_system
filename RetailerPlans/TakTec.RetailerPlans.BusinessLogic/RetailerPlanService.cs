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
            throw new NotImplementedException();
        }

        private bool ValidatePlan(RetailerPlan plan)
        {
            bool isValidOperator = _operatorRepository.Exists(plan.Operator.Id);
            bool isValidJoinAmount = plan.JoiningAmount > 0;
            bool isValidRenwalAMount = plan.RenewalAmount > 0;
            bool isValidCommissionRate = plan.CommissionRateType == CommissionRateType.FLAT_COMMISSION ||
                                         plan.CommissionRateType == CommissionRateType.PER_RECHARGE_COMMISSION;   


            // add other validation criteria
            if(isValidOperator && isValidJoinAmount && isValidRenwalAMount && isValidCommissionRate)
            {
                return true;
            }
            return false;
        }

         private RetailerPlanViewModel CreateNewPlan(RetailerPlan newPlan)
         {
            _retailerPlanRepository.Create(newPlan);
            return newPlan.ToPlanViewModel();
        }

         private RetailerPlanViewModel UpdatePlan (RetailerPlan plan)
        {
            var retPlan = _retailerPlanRepository.WithKey(plan.Id);
            if(retPlan == null)
            {
                return null;
            }
            var updatedPlan = new RetailerPlan("", ResourceTypes.GROUP,
                                plan.Code , plan.Name,
                                plan.CommissionRateType , plan.OperatorId){
                                    Description = plan.Description,
                                    JoiningAmount = plan.JoiningAmount,
                                    RenewalAmount = plan.RenewalAmount,
                                    RenewalAmountChargingRate = plan.RenewalAmountChargingRate,
                                    CommissionRates = plan.CommissionRates//is this possible
                              };
            return updatedPlan.ToPlanViewModel();
        }

        public List<RetailerPlanViewModel> ListRetailerPlans(int pageNo, int ItemsPerPage)
        {
            var plans = _retailerPlanRepository.GetCustomFilters(pageNo,ItemsPerPage).Items.ToList();//.GetCustomFilters<Operator>();
            if(plans ==null){
                _logger.AddUserError("There is no Plan in database!");
                return null;
            }
            else{
                string msg = "There are " + plans.Count + " plans";
                _logger.AddUserMesage(msg);
                return plans.ToPlanViewModelList();
            }
        }

       
    }
}
