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

        public EVDUserService(IAccountService accountService,
            ITokenUserService tokenUserService,
            IRoleTypeService roleTypeService,
            ILogger<IEVDUserService> logger,
            IStorage storage) {
            _accountService = accountService ?? 
                throw new ArgumentNullException(nameof(accountService));
            _tokenUserService = tokenUserService ??
                throw new ArgumentNullException(nameof(tokenUserService));
            _roleTypeService = roleTypeService ??
                throw new ArgumentNullException(nameof(roleTypeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger<IEVDUserService>));
            _storage = storage ?? throw new ArgumentNullException(nameof(IStorage));
        }

        

        public async Task<RegisterUserResult?> RegisterUserAsync(NewUserModel request) {
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
        }

        public List<ListUserModel> ListUsers(PagedItemRequestBase request) {
            return  _accountService.ListUsers(request).ToViewModel();
        }


    }
}
