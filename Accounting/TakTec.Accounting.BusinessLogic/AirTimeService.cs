using EthioArt.Security.Abstraction;
using EthioArt.Syncronization.Abstractions;
using EthioArt.UserAccounts.Services.Abstractions;
using ExtCore.Data.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Accounting.BusinessLogic.Abstractions;
using TakTec.Accounting.Data.Abstractions;
using TakTec.RetailerPlans.Abstractions;
using Users.BusinessLogic.Abstraction;
using System.Linq;
using Messages.Logging.Extensions;
using TakTec.Accounting.Entities;
using TakTec.RetailerPlans.Entities;
using TakTec.Users.Constants;

namespace TakTec.Accounting.BusinessLogic
{
    public class AirTimeService: IAirTimeService
    {
        //private readonly IMoneyDepositRepository _moneyDepositRepository;
        private readonly IStorage _storage;
        private readonly ITokenUserService _tokenUserService;
        private readonly ILogger<IMoneyDepositRepository> _logger;
        //private IRetailerPlanRepository _retailerPlanRepository;
        //private readonly IRoleService _roleService;
        private readonly IAccountService _accountService;
        //private readonly IOrAuthorizationService _orAuthorizationService;
        private readonly IAirTimeRepository _airTimeRepository;
        private readonly IAirTimeUpdateRepository _airTimeUpdateRepository;
        //private readonly IGlobalSyncronizationStore _globalSyncronizationStore;
        public AirTimeService(
            IStorage storage,
            ITokenUserService tokenUserService,
            ILogger<IMoneyDepositRepository> logger,
            //IRoleService roleService,
            IAccountService accountService//,
            //IOrAuthorizationService orAuthorizationService,
            //IGlobalSyncronizationStore globalSyncronizationStore
            )
        {

            _storage = storage ?? throw new ArgumentNullException(nameof(IStorage));
            //_moneyDepositRepository = _storage.GetRepository<IMoneyDepositRepository>();
            _tokenUserService = tokenUserService ??
                throw new ArgumentNullException(nameof(ITokenUserService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //_roleService = roleService ?? throw new ArgumentNullException(nameof(IRoleService));
            _accountService = accountService ??
                throw new ArgumentNullException(nameof(IAccountService));
            //_orAuthorizationService = orAuthorizationService ??
            //    throw new ArgumentNullException(nameof(IOrAuthorizationService));
            //_retailerPlanRepository = _storage.GetRepository<IRetailerPlanRepository>()
            //    ?? throw new ArgumentNullException(nameof(IRetailerPlanRepository));
            _airTimeRepository = _storage.GetRepository<IAirTimeRepository>() ??
                throw new ArgumentNullException(nameof(IAirTimeRepository));
            //_globalSyncronizationStore = globalSyncronizationStore ??
            //    throw new ArgumentNullException(nameof(IGlobalSyncronizationStore));
            _airTimeUpdateRepository = _storage.GetRepository<IAirTimeUpdateRepository>() ??
                throw new ArgumentNullException(nameof(IAirTimeUpdateRepository));

        }

        public bool RemoveAirTimeFromUser(String fromUserId, decimal airTime,
            Enumerations.AirTimeUpdateCauseType airTimeUpdateCauseType,
            String airTimeCauseId
            )
        {
            var fromUser = _accountService.GetUser(fromUserId);
            if (fromUser == null)
            {
                return false;
            }

            String fromUserRoleName = fromUser.AspNetUserRoles.FirstOrDefault().AspNetRole.Name;
            var fromUserAirTime = _airTimeRepository.WithOwnerItemId(fromUserRoleName).FirstOrDefault();
            if (fromUserAirTime == null)
            {
                return false;
            }

            return TransferAirTime(fromUserAirTime, airTime, airTimeUpdateCauseType, airTimeCauseId, true);
        }

        public bool TranserAirTimeFromCurrentUser(String toUserId, decimal airTime,
            Enumerations.AirTimeUpdateCauseType airTimeUpdateCauseType,
            String airTimeCauseId
            )
        {
            var fromAirTime = GetCurrentUserAirTime();
            var toUser = _accountService.GetUser(toUserId);
            if (toUser == null)
            {
                return false;
            }

            String toUserRoleName = toUser.AspNetUserRoles.FirstOrDefault().AspNetRole.Name;
            var toUserAirTime = _airTimeRepository.WithOwnerItemId(toUserRoleName).FirstOrDefault();
            if (toUserAirTime == null)
            {
                return false;
            }

            return TransferAirTime(fromAirTime, toUserAirTime, airTime, airTimeUpdateCauseType, airTimeCauseId);
        }

        public bool TranserAirTime(String fromUserId, String toUserId, decimal airTime,
            Enumerations.AirTimeUpdateCauseType airTimeUpdateCauseType,
            String airTimeCauseId
            )
        {
            var fromUser = _accountService.GetUser(fromUserId);
            if (fromUser == null) {
                return false;
            }
            var toUser = _accountService.GetUser(toUserId);
            if (toUser == null)
            {
                return false;
            }

            String fromUserRoleName = fromUser.AspNetUserRoles.FirstOrDefault().AspNetRole.Name;
            String toUserRoleName = toUser.AspNetUserRoles.FirstOrDefault().AspNetRole.Name;

            //check if the current user has this amount air time 
            var currUserAirTime = _airTimeRepository.
                WithOwnerItemId(fromUserRoleName).FirstOrDefault();
            if (currUserAirTime == null)
            {
                return false;
            }

            var toUserAirTime = _airTimeRepository.WithOwnerItemId(toUserRoleName).FirstOrDefault();
            if (toUserAirTime == null)
            {
                return false;
            }

            return TransferAirTime(currUserAirTime, toUserAirTime, airTime, airTimeUpdateCauseType, airTimeCauseId);


            //if (currUserAirTime.Amount < airTime)
            //{
            //    _logger.AddUserError($"Insefficient airtime error. User airtime = {currUserAirTime.Amount}, trying to transfer {airTime}.");
            //    return false;
            //}

            //AirTimeUpdate airTimeUpdate = new AirTimeUpdate(
            //    airTimeUpdateCauseType, airTimeCouseId,
            //    airTime, isCredit, toUserAirTime.Id)
            //{
            //    CreatorUserId = _tokenUserService.UserId
            //};

            //currUserAirTime.Amount -= airTime;
            //toUserAirTime.Amount += airTime;

            //_airTimeUpdateRepository.Create(airTimeUpdate);

            //return true;
        }

        private bool TransferAirTime(AirTime fromUserAirTime, 
            AirTime toUserAirTime, decimal airTime,
            Enumerations.AirTimeUpdateCauseType airTimeUpdateCauseType,
            String airTimeCouseId) {
            if (fromUserAirTime.Amount < airTime)
            {
                _logger.AddUserError($"Insefficient airtime error. User airtime = {fromUserAirTime.Amount}, trying to transfer {airTime}.");
                return false;
            }

            //AirTimeUpdate airTimeUpdate = new AirTimeUpdate(
            //    airTimeUpdateCauseType, airTimeCouseId,
            //    airTime, isCredit, toUserAirTime.Id)
            //{
            //    CreatorUserId = _tokenUserService.UserId
            //};
            //AirTimeUpdate airTimeUpdatef = new AirTimeUpdate(
            //    airTimeUpdateCauseType, airTimeCouseId,
            //    airTime, isCredit, currUserAirTime.Id)
            //{
            //    CreatorUserId = _tokenUserService.UserId
            //};

            //currUserAirTime.Amount -= airTime;
            //toUserAirTime.Amount += airTime;

            //_airTimeUpdateRepository.Create(airTimeUpdatef);
            //_airTimeUpdateRepository.Create(airTimeUpdate);
            TransferAirTime(toUserAirTime,airTime,airTimeUpdateCauseType, airTimeCouseId, false);
            TransferAirTime(fromUserAirTime, airTime, airTimeUpdateCauseType, airTimeCouseId, true);
            return true;
        }

        private bool TransferAirTime(AirTime currUserAirTime,
          decimal airTime,
          Enumerations.AirTimeUpdateCauseType airTimeUpdateCauseType,
          String airTimeCouseId,
          bool isCredit)
        {
            if (isCredit)
            {
                if (currUserAirTime.Amount < airTime)
                {
                    _logger.AddUserError($"Insefficient airtime error. User airtime = {currUserAirTime.Amount}, trying to transfer {airTime}.");
                    return false;
                }
            }


            AirTimeUpdate airTimeUpdatef = new AirTimeUpdate(
                airTimeUpdateCauseType, airTimeCouseId,
                airTime, isCredit, currUserAirTime.Id)
            {
                CreatorUserId = _tokenUserService.UserId
            };
            if (isCredit)
            {
                currUserAirTime.Amount -= airTime;
            }
            else {
                currUserAirTime.Amount += airTime;
            }
            _airTimeUpdateRepository.Create(airTimeUpdatef);
            return true;
        }



        public decimal CalculateAirTime(RetailerPlan plan, decimal amount)
        {
            switch (plan.CommissionRateType)
            {
                case RetailerPlans.Enumerations.CommissionRateType.FLAT_COMMISSION:
                    return CalculateAirTimeForFlatCommission(plan, amount);
                case RetailerPlans.Enumerations.CommissionRateType.PER_RECHARGE_COMMISSION:
                    return CalculateAirTimeForPerRechargeCommission(plan, amount);
                default:
                    throw new Exception($"Unknowne comision rate type {plan.CommissionRateType}");
            }
        }

        decimal CalculateAirTimeForFlatCommission(RetailerPlan plan, decimal amount)
        {
            var rate = plan.CommissionRates.FirstOrDefault();
            if (rate == null)
            {
                throw new Exception($"Comission rate not found for plan id {plan.Id}");
            }

            //decimal res = ((rate.Rate * amount) / 100) + amount;
            return this.CalculateAirTime(rate.Rate, amount);
        }

        decimal CalculateAirTimeForPerRechargeCommission(RetailerPlan plan, decimal amount)
        {
            var rates = plan.CommissionRates.OrderBy(x => x.Amount);
            CommissionRate? rate = null;
            foreach (var v in rates)
            {
                if (amount < v.Amount)
                {
                    rate = v;
                }
                else
                {
                    break;
                }
            }
            if (rate == null)
            {
                _logger.LogWarning($"Comission rate for amount not found. " +
                    $"Using the last amount. rate amount {rate.Amount} - rate {rate.Rate}, for amount {amount}");
                rate = plan.CommissionRates.Last();
            }

            return this.CalculateAirTime(rate.Rate, amount);
        }


        public decimal CalculateAirTime(double rate, decimal amount)
        {

            decimal res = (((decimal)rate * amount) / 100) + amount;
            return res;
        }

        public bool CreateAirTime(String ownerId) {
            AirTime airTime = new AirTime(ownerId, 0){
            };
            _airTimeRepository.Create(airTime);

            return true;
        }

        /// <summary>
        /// If the current user is the SupperAdmin it returns the systems air time
        /// otherwise it returns he users air time
        /// </summary>
        /// <returns></returns>       
        public AirTime GetCurrentUserAirTime() {
            String userRole = _tokenUserService.UserRole;
            if (userRole.Equals(RoleTypeConstants.RoleNameSupperAdmin))
            {
                return this.GetSystemAirTime();
            }
            else {
                var airTime = _airTimeRepository.WithOwnerItemId(userRole).FirstOrDefault();
                if (airTime == null)
                {
                    throw new NullReferenceException($" User airtime not found.");
                }
                return airTime;
            }           
        }

        public AirTime GetSystemAirTime()
        {            
            var airTime = _airTimeRepository.WithOwnerItemId(RoleTypeConstants.RoleNameSystem).FirstOrDefault();
            if (airTime == null)
            {
                throw new NullReferenceException($" System airtime not found.");
            }
            return airTime;
        }


    }
}
