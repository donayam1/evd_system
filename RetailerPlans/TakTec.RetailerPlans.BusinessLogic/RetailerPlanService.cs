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

        public RetailerPlanViewModel? CreateorUpdatePlan(RetailerPlanViewModel retPlan)
        {
            //TODO create and update
            //RetailerPlan retPlan = retailerPlanModel.ToPlanDomailModel();

            if(!ValidatePlan(retPlan))
            {
                _logger.AddUserError("Invalid request");
                return null;
            }

            RetailerPlan? plan;

            switch (retPlan.Status)
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
                    return retPlan;
            }

            if (plan != null)
            {
                try
                {
                    _storage.Save();

                    var planViewModel = plan.ToNewPlanViewModel(retPlan.Id);
                    return planViewModel;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.InnerException, e.Message);
                    _logger.AddUserError("Unknown error. Please contact administrator.");
                    return null;
                }
            }
            
           return null;
            

        }
        private bool ValidatePlan(RetailerPlanViewModel plan)
        {
            //TODO check if the owner of the plan exists ie the user is valid user or not
            bool isValidOperator = _operatorRepository.Exists(plan.OperatorId);

            bool isValidJoinAmount = plan.JoinAmount >= 0;
            bool isValidRenwalAMount = plan.RenewalAmount >= 0;
            bool isValidCommissionRate = plan.CommissionRateType == CommissionRateType.FLAT_COMMISSION ||
                                         plan.CommissionRateType == CommissionRateType.PER_RECHARGE_COMMISSION;


            // add other validation criteria
            if (isValidOperator && isValidJoinAmount && isValidRenwalAMount && isValidCommissionRate)
            {               
            }
            else
            {
                return false;
            }

            RetailerPlan? _plan = _retailerPlanRepository.WithName(plan.Name);
            

            if (plan.Status != ObjectStatusEnum.NEW)
            {
                bool exists = _retailerPlanRepository.Exists(plan.Id);
                if (!exists)
                {
                    _logger.AddUserError("Plan does not exist!");
                    return false;
                }

                if (_plan != null && !_plan.Id.Equals( plan.Id))
                {
                    _logger.AddUserError($"Plan with name  {_plan.Name} exists!");
                    return false;
                }
                             
            }

            else if(plan.Status == ObjectStatusEnum.NEW)
            {                
            }
            return true;
        }

        //private bool isValidRequest(RetailerPlan plan)
        //{
        //    bool isValidOperator = _operatorRepository.Exists(plan.OperatorId);

        //    bool isValidJoinAmount = plan.JoiningAmount >= 0;
        //    bool isValidRenwalAMount = plan.RenewalAmount >= 0;
        //    bool isValidCommissionRate = plan.CommissionRateType == CommissionRateType.FLAT_COMMISSION ||
        //                                 plan.CommissionRateType == CommissionRateType.PER_RECHARGE_COMMISSION;   


        //    // add other validation criteria
        //    if(isValidOperator && isValidJoinAmount && isValidRenwalAMount && isValidCommissionRate)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

         private RetailerPlan CreateNewPlan(RetailerPlanViewModel newPlan)
         {
            String ownerId = _tokenUserService.UserRole;
            var model = newPlan.ToPlanDomailModel(ownerId);
            _retailerPlanRepository.Create(model);
            return model;
        }

        private RetailerPlan UpdatePlan(RetailerPlanViewModel retailerPlan)
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
        private RetailerPlan? RemovePlan(RetailerPlanViewModel plan){
            return null;
        }

       
    }
}
