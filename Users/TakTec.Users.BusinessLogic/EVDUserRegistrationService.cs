using EthioArt.UserAccounts.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Users.BusinessLogic.Abstractions;
using TakTec.Users.ViewModels;

namespace TakTec.Users.BusinessLogic
{
    public class EVDUserRegistrationService:
        IEVDUserRegistrationService
    {
        private readonly IAccountService _accountService;
        public EVDUserRegistrationService(IAccountService accountService) {
            _accountService = accountService ?? 
                throw new ArgumentNullException(nameof(accountService));
        }
        public void RegisterUser(NewUserModel request) { 

        }
    }
}
