using EthioArt.Security.Abstraction;
using EthioArt.Security.Requirements;
using EthioArt.Syncronization.Abstractions;
using EthioArt.UserAccounts.Services.Abstractions;
using ExtCore.Data.Abstractions;
using Messages.Logging.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
//using Roles.BusinessLogic.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakTec.Accounting.BusinessLogic.Abstractions;
using TakTec.Accounting.Data.Abstractions;
using TakTec.Accounting.ObjectMappers;
//using TakTec.Accounting.Entities;
using TakTec.Accounting.ViewModels;
using TakTec.RetailerPlans.Abstractions;
//using TakTec.RetailerPlans.Entities;
using Users.BusinessLogic.Abstraction;

namespace TakTec.Accounting.BusinessLogic
{
    public class MoneyDepositService: IMoneyDepositService
    {
        private readonly IMoneyDepositRepository _moneyDepositRepository;
        private readonly IStorage _storage;
        private readonly ITokenUserService _tokenUserService;
        private readonly ILogger<IMoneyDepositRepository> _logger;
        private IRetailerPlanRepository _retailerPlanRepository;
        private IUserPlanRepository _userPlanRepository;
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
            _userPlanRepository = _storage.GetRepository<IUserPlanRepository>() ??
                throw new ArgumentNullException(nameof(IUserPlanRepository));
            _airTimeRepository = _storage.GetRepository<IAirTimeRepository>() ??
                throw new ArgumentNullException(nameof(IAirTimeRepository));
            _globalSyncronizationStore = globalSyncronizationStore ??
                throw new ArgumentNullException(nameof(IGlobalSyncronizationStore));
            _airTimeService = airTimeService ?? throw new ArgumentNullException(nameof(IAirTimeService));

        }

        public bool ApproveMoneyDeposit(ApproveMoneyDepositRequest request)
        {
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
            var toUser = _accountService.GetUser(mdReq.ForUserId);
            if (toUser == null)
            {
                return false;
            }

            //String fromUserRoleName = fromUser.AspNetUserRoles.FirstOrDefault().AspNetRole.Name;
            String toUserRoleName = toUser.AspNetUserRoles.FirstOrDefault().AspNetRole.Name;
            var toUserAirTime = _airTimeRepository.WithOwnerItemId(toUserRoleName).FirstOrDefault();
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
                bool res = this.approveMoneyDeposit(request).Result;
                return res;
            }
            , request, locables);

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
        
        async Task<bool> approveMoneyDeposit(ApproveMoneyDepositRequest request) {

            if (! await validateApproveRequest(request)) {
                _logger.AddUserError("Invalid request");
                return false;
            }

            var mdReq = _moneyDepositRepository.WithKey(request.Id);
            var retailerPlan = _retailerPlanRepository.WithKey(mdReq.RetailerPlanId);

            decimal airTime =this._airTimeService.CalculateAirTime(retailerPlan, mdReq.Amount);

            
            bool res = this._airTimeService.TranserAirTime(_tokenUserService.UserId, mdReq.ForUserId, airTime,
                Enumerations.AirTimeUpdateCauseType.MONEY_DEPOSIT,
                mdReq.Id,false);

            if (res == false) {
                _logger.AddUserError("Air time transfer failed");
                return false;
            }

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

        public List<MoneyDepositModel> ListDeposits(ListMoneyDepositsRequest request) {

            //TODO filer only deposits the current user can see.

            var res = this._moneyDepositRepository.All(request.IsSyncing, request.FromDate, request.ToDate)
                .Where(x => x.IsAproved == request.IsApproved).ToList();

            return res.ToViewModel();
        }

        bool ValidateMoneyDeposit(MoneyDepositModel request) {
            return true;
        }

        public MoneyDepositModel? CreateDeposit(MoneyDepositModel request)
        {
            if (!ValidateMoneyDeposit(request)) {
                return null;
            }


            var user = _accountService.GetUser(request.ForUserId);
            String userRoleName = user.AspNetUserRoles.FirstOrDefault().AspNetRole.Name;

            var plan = _userPlanRepository.GetCurrentPlan(userRoleName);


            var moneyDepositRequest = request.ToDomainModel(_tokenUserService.UserId, 
                plan.Id,
                userRoleName
                );

            _moneyDepositRepository.Create(moneyDepositRequest);

            try {
                _storage.Save();
                return moneyDepositRequest.ToViewModel();
            }
            catch (Exception e) {
                _logger.LogError(e, $"{e.Message}-{e.StackTrace}-{e.InnerException}");
            }

            return null;
        }
    }
}
