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
using TakTec.Users.Constants;
using Users.BusinessLogic.Abstraction;

namespace TakTec.RetailerPlans.BusinessLogic
{
    public class RetailerPlanService : IRetailerPlanService
    {

        private readonly IRetailerPlanRepository _retailerPlanRepository;
        private readonly ILogger<IRetailerPlanService> _logger;
        private readonly IStorage _storage;
        private readonly IOperatorRepository _operatorRepository; 
        private readonly ITokenUserService _tokenUserService;


        public RetailerPlanService(IStorage storage,ILogger<IRetailerPlanService> logger,ITokenUserService tokenUserService)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _retailerPlanRepository = _storage.GetRepository<IRetailerPlanRepository>()??
                                     throw new ArgumentNullException(nameof(IRetailerPlanRepository));
            _operatorRepository = _storage.GetRepository<IOperatorRepository>()??
                                     throw new ArgumentNullException(nameof(IOperatorRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tokenUserService = tokenUserService ?? throw new ArgumentNullException(nameof(tokenUserService));

        }

        public RetailerPlanViewModel? CreateorUpdatePlan(RetailerPlanViewModel retailerPlanModel)
        {
            //TODO create and update
            RetailerPlan retPlan = retailerPlanModel.ToPlanDomailModel();

            if(!(isValidRequest(retPlan)|| ValidatePlan(retPlan,retailerPlanModel.Status)))
            {
                _logger.AddUserError("Invalid request");
                return null;
            }

            RetailerPlan? plan;

            switch (retailerPlanModel.Status)
            {
                case ObjectStatusEnum.NEW:
                    plan = CreateNewPlan(retPlan);
                    break;
                case ObjectStatusEnum.EDITTED:
                    plan = UpdatePlan(retPlan);
                    break;
                case ObjectStatusEnum.REMOVED:
                    plan = RemovePlan(retPlan);
                    break;
                default:
                    return retailerPlanModel;
            }

            if (plan != null)
            {
                try
                {
                    _storage.Save();
                }
                catch (Exception e)
                {
                    _logger.LogError(e.InnerException, e.Message);
                    _logger.AddUserError("Unknown error. Please contact administrator.");
                    return null;
                }
            }
            var planViewModel = plan.ToPlanViewModel();
            return planViewModel;
                
            

        }
        private bool ValidatePlan(RetailerPlan plan,ObjectStatusEnum status)
        {
            //TODO check if the owner of the plan exists ie the user is valid user or not

            RetailerPlan _plan = _retailerPlanRepository.WithCodeorWithName(plan);
            if(status != ObjectStatusEnum.NEW)
            {
                bool exists = _retailerPlanRepository.Exists(plan.Id);
                if(!exists)
                {
                    _logger.AddUserError("Plan does not exist!");
                    return false;
                }
                if(_plan != null)
                {
                    _logger.AddUserError("Plan with name"+_plan.Name+" and code"+_plan.Code+"exists!");
                    return false;
                }
            }

            else if(status == ObjectStatusEnum.NEW)
            {
                if(_plan != null)
                {
                    _logger.AddUserError("Plan with name"+_plan.Name+" and code"+_plan.Code+"exists!");
                    return false;
                }
            }
            return true;
        }

        private bool isValidRequest(RetailerPlan plan)
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
            var result = _retailerPlanRepository.WithKey(retailerPlan.Id);
            result.Name = retailerPlan.Name;
            result.Code = retailerPlan.Code;
            result.Description = retailerPlan.Description;
            
            _retailerPlanRepository.Edit(result);
            return result;
        }

        public List<RetailerPlanViewModel>? ListRetailerPlans(int pageNo, int ItemsPerPage)
        {
            string? userRole = _tokenUserService.UserRole;
            var plans = _retailerPlanRepository.Getplans(userRole)
                                               .Skip(ItemsPerPage*(pageNo-1))
                                               .Take(ItemsPerPage)
                                               .ToList();
            if(plans ==null)
            {
                _logger.AddUserError("There is no Plan in database!");
                return null;
            }
           
            string msg = "There are " + plans.Count + " plans";
            _logger.AddUserMesage(msg);
            return plans.ToPlanViewModelList();
            

           
        }
        private RetailerPlan? RemovePlan(RetailerPlan plan){
            return null;
        }

       
    }
}
