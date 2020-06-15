using EthioArt.UserAccounts.Services.Abstractions;
using Messages.Logging.Extensions;
using Microsoft.Extensions.Logging;
using Roles.BusinessLogic.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Users.BusinessLogic.Abstractions;
using TakTec.Users.ViewModels;
using Users.BusinessLogic.Abstraction;
using EthioArt.UserAccounts.Models;
using System.Threading.Tasks;
using ExtCore.Data.Abstractions;
using AspNetIdentity.Data.Entities;
using EthioArt.Backend.Models.Requests;
using TakTec.Users.ObjectMappers;
using TakTec.RetailerPlans.BusinessLogic.Abstraction;
using TakTec.Accounting.BusinessLogic.Abstractions;

namespace TakTec.Users.BusinessLogic
{
    public class EVDUserService:
        IEVDUserService
    {
        private readonly IAccountService _accountService;
        private readonly ITokenUserService _tokenUserService;
        private readonly IRoleTypeService _roleTypeService;
        private readonly ILogger<IEVDUserService> _logger;
        private readonly IStorage _storage;
        private readonly IRetailerPlanService _retailerPlanService;
        private readonly IAirTimeService _airTimeService;

        public EVDUserService(IAccountService accountService,
            ITokenUserService tokenUserService,
            IRoleTypeService roleTypeService,
            ILogger<IEVDUserService> logger,
            IStorage storage,
            IRetailerPlanService retailerPlanService, 
            IAirTimeService airTimeService) {

            _accountService = accountService ?? 
                throw new ArgumentNullException(nameof(accountService));
            _tokenUserService = tokenUserService ??
                throw new ArgumentNullException(nameof(tokenUserService));
            _roleTypeService = roleTypeService ??
                throw new ArgumentNullException(nameof(roleTypeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger<IEVDUserService>));
            _storage = storage ?? throw new ArgumentNullException(nameof(IStorage));
            _retailerPlanService = retailerPlanService ??
                throw new ArgumentNullException(nameof(retailerPlanService));
            _airTimeService = airTimeService ??
                throw new ArgumentNullException(nameof(airTimeService));
        }

        

        public async Task<RegisterUserResult?> RegisterUserAsync(NewUserModel request) {
            request.Password = "000000";
            var res= await _accountService.CreateUser(request);
            if (res != null)
            {

                //TODO. Assert that the current user owns the plan.

                var ares = _retailerPlanService.AddUserToPlan(res.Role.Name, request.PlanId);
                if (ares == false) {
                    _logger.LogError("Error adding user to retailer plan");
                    return null;
                }

                var airTimeRes = _airTimeService.CreateAirTime(res.Role.Name);
                if (airTimeRes == false) {
                    _logger.LogError("Error creating airtime.");
                    return null;
                }

                try
                {
                    _storage.Save();//TODO improve this a lot 
                }
                catch (Exception e)
                {
                    _logger.LogError("Error:" + e.Message);
                    return null;
                }
            }
            return res;
        }

        public List<ListUserModel> ListUsers(PagedItemRequestBase request) {
            return  _accountService.ListUsers(request).ToViewModel();
        }


    }
}
