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

namespace TakTec.Users.BusinessLogic
{
    public class NewUserValidator : INewUserValidator
    {

        //private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;

        private readonly ITokenUserService _tokenUserService;
        private readonly IRoleTypeService _roleTypeService;
        private readonly ILogger<IEVDUserRegistrationService> _logger;
        public NewUserValidator(//IAccountService accountService,
            ITokenUserService tokenUserService,
            IRoleTypeService roleTypeService,
            ILogger<IEVDUserRegistrationService> logger,
            IRoleService roleService)
        {
            _roleService = roleService ??
                throw new ArgumentNullException(nameof(IRoleService));
            _tokenUserService = tokenUserService ??
                throw new ArgumentNullException(nameof(tokenUserService));
            _roleTypeService = roleTypeService ??
                throw new ArgumentNullException(nameof(roleTypeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger<IEVDUserRegistrationService>));
        }

        

        public bool Validate(RegisterUserRequest request)
        {
            NewUserModel model = (NewUserModel)request;

            var userRole = _roleService.GetUserRole(_tokenUserService.UserId);
            var requestedRole = _roleTypeService.GetRoleType(request.RoleTypeId);

            if (userRole == null || requestedRole == null)
            {
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
    }
}
