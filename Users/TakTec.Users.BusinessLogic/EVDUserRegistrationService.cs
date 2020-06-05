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

namespace TakTec.Users.BusinessLogic
{
    public class EVDUserRegistrationService:
        IEVDUserRegistrationService
    {
        private readonly IAccountService _accountService;
        private readonly ITokenUserService _tokenUserService;
        private readonly IRoleTypeService _roleTypeService;
        private readonly ILogger<IEVDUserRegistrationService> _logger;
        private readonly IStorage _storage;

        public EVDUserRegistrationService(IAccountService accountService,
            ITokenUserService tokenUserService,
            IRoleTypeService roleTypeService,
            ILogger<IEVDUserRegistrationService> logger,
            IStorage storage) {
            _accountService = accountService ?? 
                throw new ArgumentNullException(nameof(accountService));
            _tokenUserService = tokenUserService ??
                throw new ArgumentNullException(nameof(tokenUserService));
            _roleTypeService = roleTypeService ??
                throw new ArgumentNullException(nameof(roleTypeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger<IEVDUserRegistrationService>));
            _storage = storage ?? throw new ArgumentNullException(nameof(IStorage));
        }

        //bool ValidateRequest(NewUserModel request) {

        //    var userRole = _accountService.GetUserRole(_tokenUserService.UserId);
        //    var requestedRole = _roleTypeService.GetRoleType(request.RoleTypeId);

        //    if (userRole == null || requestedRole == null) {
        //        _logger.LogError($" User Role Type = {userRole} and Requested Role Type ={requestedRole}");
        //        return false;
        //    }

        //    if (requestedRole.Rank > userRole.AspNetRoleType?.Rank)
        //    {
        //        _logger.AddUnauthorizedError();
        //        return false;
        //    }
            
        //    return true;
        //}

        public async Task<RegisterUserResult?> RegisterUserAsync(NewUserModel request) {
            
            //if (!ValidateRequest(request)) {
            //    return;    
            //}

            //var userRole = _accountService.GetUserRole(_tokenUserService.UserId);
            //var requestedRole = _roleTypeService.GetRoleType(request.RoleTypeId);

            //RegisterUserRequest req = new RegisterUserRequest() { 
            //      Email = request.Email,
            //      Password = "00000",
            //      RoleTypeId = request.RankId
            //};

            request.Password = "000000";
            var res= await _accountService.CreateUser(request);
            if (res != null)
            {

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
            
            //if (requestedRole.Rank == userRole.AspNetRoleType?.Rank) { 
            //    // create an alies user
            //}
            //else // create a lower rank user 
            //{ 
            //}
            //request.RankId

        }
    }
}
