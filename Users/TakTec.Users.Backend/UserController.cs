using System;
using System.Threading.Tasks;
using EthioArt.Backend.Models;
using EthioArt.UserAccounts.Models;
using Messages.BusinessLogic.Abstraction;
using Messages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakTec.Core.Security;
using TakTec.Users.BusinessLogic.Abstractions;
using TakTec.Users.ViewModels;

namespace TakTec.Users.Backend
{
    [Route("/api/evd/users/[Controller]")]
    [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName)]
    public class UserController:ControllersBase
    {
        private readonly IEVDUserRegistrationService _eVDUserRegistrationService;
        public UserController(IUserMessageLogges logges,
            IEVDUserRegistrationService eVDUserRegistrationService
            ) : base(logges) {
            _eVDUserRegistrationService = eVDUserRegistrationService ??
                throw new ArgumentNullException(nameof(IEVDUserRegistrationService));
        }

        public async Task<IActionResult> RegisterUser([FromBody]NewUserModel request) {
            if (ModelState.IsValid) {
                NewUserResponse response = new NewUserResponse();

                var res = await _eVDUserRegistrationService.RegisterUserAsync(request);
                if (res == null)
                {
                    response.Status = false;
                }
                else {
                    response.Status = true;
                    response.Result = res;
                }
                return SendResult(response);
            }
            return BadRequest(ModelState);
        }


    }
}
