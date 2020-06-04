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

namespace TakTec.Users.BusinessLogic
{
    public class EVDUserRegistrationService:
        IEVDUserRegistrationService
    {
        private readonly IAccountService _accountService;
        private readonly ITokenUserService _tokenUserService;
        private readonly IRoleTypeService _roleTypeService;
        private readonly ILogger<IEVDUserRegistrationService> _logger;
        public EVDUserRegistrationService(IAccountService accountService,
            ITokenUserService tokenUserService,
            IRoleTypeService roleTypeService,
            ILogger<IEVDUserRegistrationService> logger) {
            _accountService = accountService ?? 
                throw new ArgumentNullException(nameof(accountService));
            _tokenUserService = tokenUserService ??
                throw new ArgumentNullException(nameof(tokenUserService));
            _roleTypeService = roleTypeService ??
                throw new ArgumentNullException(nameof(roleTypeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger<IEVDUserRegistrationService>));
        }

        bool ValidateRequest(NewUserModel request) {

            var userRole = _accountService.GetUserRole(_tokenUserService.UserId);
            var requestedRole = _roleTypeService.GetRoleType(request.RankId);

            if (userRole == null || requestedRole == null) {
                _logger.LogError($" User Role Type = {userRole} and Requested Role Type ={requestedRole}");
                return false;
            }

            if (requestedRole.Rank > userRole.AspNetRoleType?.Rank)
            {
                _logger.AddUnauthorizedError();
                return false;
            }
            
            return true;
        }

        public void RegisterUser(NewUserModel request) {

            if (!ValidateRequest(request)) {
                return;    
            }
            var userRole = _accountService.GetUserRole(_tokenUserService.UserId);
            var requestedRole = _roleTypeService.GetRoleType(request.RankId);


            if (requestedRole.Rank == userRole.AspNetRoleType?.Rank) { 
                // create an alies user

            }
            else // create a lower rank user 
            { 

            }


            //request.RankId

        }
    }
}
