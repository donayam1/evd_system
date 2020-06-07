using System;
using System.Threading.Tasks;
using EthioArt.Backend.Models;
using EthioArt.Backend.Models.Requests;
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
        private readonly IEVDUserService _eVDUserRegistrationService;
        public UserController(IUserMessageLogges logges,
            IEVDUserService eVDUserRegistrationService
            ) : base(logges) {
            _eVDUserRegistrationService = eVDUserRegistrationService ??
                throw new ArgumentNullException(nameof(IEVDUserService));
        }

        [HttpPost]
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

        [HttpGet]
        public IActionResult ListUsers([FromQuery]PagedItemRequestBase request) {
            if (ModelState.IsValid) {
                
                var x = _eVDUserRegistrationService.ListUsers(request);
                ListUsersResponse response = new ListUsersResponse()
                {
                    Status = true,
                    Users = x
                };
                return SendResult(response);
            }
            return BadRequest(ModelState);
        }

    }
}
