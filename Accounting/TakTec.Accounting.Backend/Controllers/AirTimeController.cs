using EthioArt.Backend.Models.Requests;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Accounting.BusinessLogic.Abstractions;
using TakTec.Accounting.ViewModels;
using TakTec.Core.Security;

namespace TakTec.Accounting.Backend.Controllers
{
    [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName)]
    public class AirTimeController: AccountingControllersBase
    {
        private readonly IAirTimeService _airTimeService;
        public AirTimeController(IUserMessageLogges userMessageLogges, IAirTimeService airTimeService)
                             : base(userMessageLogges)
        {
            _airTimeService = airTimeService ?? throw new ArgumentNullException(nameof(IAirTimeService));
        }

        [HttpGet]
        public IActionResult GetUserAirTime([FromQuery] SynchronizeItemRequestBase request)
        {
            var res = _airTimeService.GetCurrentUserAirTime(request);
            GetAirTimeResponse response = new GetAirTimeResponse()
            {
                Status = true,
                AirTime = res

            };
            return SendResult(response);
        }
    }
}
