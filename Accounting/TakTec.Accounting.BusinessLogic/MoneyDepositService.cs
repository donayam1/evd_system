using EthioArt.Security.Abstraction;
using EthioArt.Security.Requirements;
using EthioArt.Syncronization.Abstractions;
using EthioArt.UserAccounts.Services.Abstractions;
using ExtCore.Data.Abstractions;
using Messages.Logging.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Roles.BusinessLogic.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakTec.Accounting.BusinessLogic.Abstractions;
using TakTec.Accounting.Data.Abstractions;
using TakTec.Accounting.Entities;
using TakTec.Accounting.ViewModels;
using TakTec.RetailerPlans.Abstractions;
using TakTec.RetailerPlans.Entities;
using Users.BusinessLogic.Abstraction;

namespace TakTec.Accounting.BusinessLogic
{
    public class MoneyDepositService
    {
        private readonly IMoneyDepositRepository _moneyDepositRepository;
        private readonly IStorage _storage;
        private readonly ITokenUserService _tokenUserService;
        private readonly ILogger<IMoneyDepositRepository> _logger;
        private IRetailerPlanRepository _retailerPlanRepository;
        //private readonly IRoleService _roleService;
        private readonly IAccountService _accountService;
        private readonly IOrAuthorizationService _orAuthorizationService;
        private readonly IAirTimeRepository _airTimeRepository;
        private readonly IGlobalSyncronizationStore _globalSyncronizationStore;
        private readonly IAirTimeService _airTimeService;

        public MoneyDepositService(IStorage storage,
            ITokenUserService tokenUserService,
            ILogger<IMoneyDepositRepository> logger,
            //IRoleService roleService,
            IAccountService accountService,
            IOrAuthorizationService orAuthorizationService,
            IGlobalSyncronizationStore globalSyncronizationStore,
            IAirTimeService airTimeService) {

            _storage = storage ?? throw new ArgumentNullException(nameof(IStorage));
            _moneyDepositRepository = _storage.GetRepository<IMoneyDepositRepository>();
            _tokenUserService = tokenUserService ?? 
                throw new ArgumentNullException(nameof(ITokenUserService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //_roleService = roleService ?? throw new ArgumentNullException(nameof(IRoleService));
            _accountService = accountService ?? 
                throw new ArgumentNullException(nameof(IAccountService));
            _orAuthorizationService = orAuthorizationService ?? 
                throw new ArgumentNullException(nameof(IOrAuthorizationService));
            _retailerPlanRepository = _storage.GetRepository<IRetailerPlanRepository>()
                ?? throw new ArgumentNullException(nameof(IRetailerPlanRepository));
            _airTimeRepository = _storage.GetRepository<IAirTimeRepository>() ??
                throw new ArgumentNullException(nameof(IAirTimeRepository));
            _globalSyncronizationStore = globalSyncronizationStore ??
                throw new ArgumentNullException(nameof(IGlobalSyncronizationStore));
            _airTimeService = airTimeService ?? throw new ArgumentNullException(nameof(IAirTimeService));

        }

       

        async Task<bool> validateApproveRequest(ApproveMoneyDepositRequest request) {
            var mdReq = _moneyDepositRepository.WithKey(request.Id);
            if (mdReq == null) {
                _logger.AddUserError("Money Deposit request not found.");
                return false;
            }
            if (mdReq.IsAproved == true) {
                _logger.AddUserError("Money Deposit has already been approved.");
                return false;
            }

            //String forUserRoleName = mdReq.ForUserRoleName;
            //var userRole = _roleService.GetRoleWithName(forUserRoleName);

            var user = _accountService.GetUser(mdReq.ForUserId);
            if (user == null) {
                _logger.AddUserError("Unknowen error, Please contact the admin");
                _logger.LogError($"User with id {mdReq.ForUserId} not found.");
                return false;
            }
            var userRole = user.AspNetUserRoles.FirstOrDefault().AspNetRole;
            if (userRole == null) {
                _logger.AddUserError("Unknowen error, Please contact the admin");
                _logger.LogError($"User with role {mdReq.ForUserId} not found.");
                return false;
            }
            bool res= await _orAuthorizationService.AuthorizeAsync(_tokenUserService.User, userRole,
                new List<IAuthorizationRequirement>()
                {
                    new UserOwnesItemRequirement()
                });
            if (!res) {
                _logger.AddUnauthorizedError();
                return false;
            }

            return true;
        }
        public async Task<bool> ApproveMoneyDeposit(ApproveMoneyDepositRequest request) {
            var mdReq = _moneyDepositRepository.WithKey(request.Id);
            if (mdReq == null)
            {
                _logger.AddUserError("Money Deposit request not found.");
                return false;
            }

            //check if the current user has this amount air time 
            var currUserAirTime = _airTimeRepository.
                WithOwnerItemId(_tokenUserService.UserRole).FirstOrDefault();
            if (currUserAirTime == null)
            {
                return false;
            }

            var toUserAirTime = _airTimeRepository.WithOwnerItemId(mdReq.ForUserId).FirstOrDefault();
            if (toUserAirTime == null)
            {
                return false;
            }

            List<ILocable> locables = new List<ILocable>() { 
                currUserAirTime,
                toUserAirTime
            };

            return _globalSyncronizationStore.LockAndExecute((x) =>
            {
                bool res =  this.approveMoneyDeposit(request).Result;
                return res;
            }
            ,request,  locables);

        }

        public async Task<bool> approveMoneyDeposit(ApproveMoneyDepositRequest request) {

            if (! await validateApproveRequest(request)) {
                _logger.AddUserError("Invalid request");
                return false;
            }

            var mdReq = _moneyDepositRepository.WithKey(request.Id);
            var retailerPlan = _retailerPlanRepository.WithKey(mdReq.RetailerPlanId);

            decimal airTime = CalculateAirTime(retailerPlan, mdReq.Amount);

            
            bool res = this._airTimeService.TranserAirTime(_tokenUserService.UserId, mdReq.ForUserId, airTime,
                Enumerations.AirTimeUpdateCauseType.MONEY_DEPOSIT,
                mdReq.Id,false);

            try
            {
                _storage.Save();
                return false;
            }
            catch (Exception e) {
                _logger.LogError(e, $"{e.Message}-{e.InnerException}");
            }


            return false;
        }

        // bool transerAirTime(String fromUserId, String toUserId, decimal airTime,
        //      Enumerations.AirTimeUpdateCauseType airTimeUpdateCauseType,
        //      String airTimeCouseId,
        //      bool isCredit
        //      ) {

        //    //check if the current user has this amount air time 
        //    var currUserAirTime = _airTimeRepository.
        //        WithOwnerItemId(_tokenUserService.UserRole).FirstOrDefault();
        //    if (currUserAirTime == null)
        //    {
        //        return false;
        //    }

        //    var toUserAirTime = _airTimeRepository.WithOwnerItemId(toUserId).FirstOrDefault();
        //    if (toUserAirTime == null)
        //    {
        //        return false;
        //    }

        //    if (currUserAirTime.Amount < airTime)
        //    {
        //        _logger.AddUserError($"Insefficient airtime error. User airtime = {currUserAirTime.Amount}, trying to transfer {airTime}.");
        //        return false;
        //    }

        //    AirTimeUpdate airTimeUpdate = new AirTimeUpdate(
        //        airTimeUpdateCauseType, airTimeCouseId,
        //        airTime,isCredit, toUserAirTime.Id);

        //    currUserAirTime.Amount -= airTime;
        //    toUserAirTime.Amount += airTime;
            

        //    return true;
        //}

        decimal CalculateAirTime(RetailerPlan plan, decimal amount) {
            switch (plan.CommissionRateType) {
                case RetailerPlans.Enumerations.CommissionRateType.FLAT_COMMISSION:
                    return CalculateAirTimeForFlatCommission(plan, amount);                    
                case RetailerPlans.Enumerations.CommissionRateType.PER_RECHARGE_COMMISSION:
                    return CalculateAirTimeForPerRechargeCommission(plan, amount);
                default:
                    throw new Exception($"Unknowne comision rate type {plan.CommissionRateType}");                    
            }            
        }

        decimal CalculateAirTimeForFlatCommission(RetailerPlan plan, decimal amount) {
            var rate = plan.CommissionRates.FirstOrDefault();
            if (rate == null) {
                throw new Exception($"Comission rate not found for plan id {plan.Id}");                
            }

            //decimal res = ((rate.Rate * amount) / 100) + amount;
            return this._airTimeService.CalculateAirTime(rate.Rate,amount);
        }

        decimal CalculateAirTimeForPerRechargeCommission(RetailerPlan plan, decimal amount)
        {
            var rates = plan.CommissionRates.OrderBy(x => x.Amount);
            CommissionRate? rate = null;
            foreach (var v in rates) {
                if (amount < v.Amount )
                {
                    rate = v;
                }
                else {
                    break;
                }
            }
            if (rate == null) {
                _logger.LogWarning($"Comission rate for amount not found. " +
                    $"Using the last amount. rate amount {rate.Amount} - rate {rate.Rate}, for amount {amount}");
                rate = plan.CommissionRates.Last();
            }

            return this._airTimeService.CalculateAirTime(rate.Rate, amount);            
        }

        //decimal CalculateAirTime(double rate, decimal amount) {

        //    decimal res = (((decimal)rate * amount) / 100) + amount;
        //    return res;
        //}



    }
}
