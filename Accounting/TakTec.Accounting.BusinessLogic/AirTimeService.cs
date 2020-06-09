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

namespace TakTec.Accounting.BusinessLogic
{
    public class AirTimeService: IAirTimeService
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
        private readonly IAirTimeUpdateRepository _airTimeUpdateRepository;
        private readonly IGlobalSyncronizationStore _globalSyncronizationStore;
        public AirTimeService(IStorage storage,
            ITokenUserService tokenUserService,
            ILogger<IMoneyDepositRepository> logger,
            //IRoleService roleService,
            IAccountService accountService,
            IOrAuthorizationService orAuthorizationService,
            IGlobalSyncronizationStore globalSyncronizationStore)
        {

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
            _airTimeUpdateRepository = _storage.GetRepository<IAirTimeUpdateRepository>() ??
                throw new ArgumentNullException(nameof(IAirTimeUpdateRepository));

        }




        public bool TranserAirTime(String fromUserId, String toUserId, decimal airTime,
            Enumerations.AirTimeUpdateCauseType airTimeUpdateCauseType,
            String airTimeCouseId,
            bool isCredit
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

            if (currUserAirTime.Amount < airTime)
            {
                _logger.AddUserError($"Insefficient airtime error. User airtime = {currUserAirTime.Amount}, trying to transfer {airTime}.");
                return false;
            }

            AirTimeUpdate airTimeUpdate = new AirTimeUpdate(
                airTimeUpdateCauseType, airTimeCouseId,
                airTime, isCredit, toUserAirTime.Id)
            {
                CreatorUserId = _tokenUserService.UserId
            };

            currUserAirTime.Amount -= airTime;
            toUserAirTime.Amount += airTime;

            _airTimeUpdateRepository.Create(airTimeUpdate);

            return true;
        }

        public decimal CalculateAirTime(double rate, decimal amount)
        {

            decimal res = (((decimal)rate * amount) / 100) + amount;
            return res;
        }

    }
}
