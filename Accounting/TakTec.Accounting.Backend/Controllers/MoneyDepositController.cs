using System;
using System.Threading;
using System.Threading.Tasks;
using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Mvc;
using EthioArt.Backend.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using TakTec.Accounting.Entities;
using TakTec.Accounting.ViewModels;
using TakTec.Accounting.BusinessLogic.Abstractions;
using System.Collections.Generic;
using TakTec.Core.Security;
using EthioArt.Backend.Models.Responses;

namespace TakTec.Accounting.Backend.Controllers
{
    //[Route("api/accounting/[controller]")]
    [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName)]
    public class MoneyDepositController: AccountingControllersBase
    {
        private readonly IMoneyDepositService _moneyDepositService;
        public MoneyDepositController(IUserMessageLogges userMessageLogges,
            IMoneyDepositService moneyDepositService)
                             :base(userMessageLogges)
        {
            _moneyDepositService = moneyDepositService ?? 
                throw new ArgumentNullException(nameof(IMoneyDepositService));
        }

        [HttpGet(template: "list")]
        public IActionResult ListDeposis([FromQuery]ListMoneyDepositsRequest request)
        {
            var bankList = new GenericResponseBase<List<MoneyDepositModel>>();
            if (ModelState.IsValid)
            {
                var deposits = _moneyDepositService.ListDeposits(request);
                if (deposits == null)
                {
                    bankList.Status = false;
                }
                else
                {
                    bankList.Status = true;
                    bankList.Response = deposits;
                }

                return SendResult(bankList);
            }

            return BadRequest(ModelState);
        }

        [HttpPost(template: "approve")]
        public IActionResult Approve([FromBody] ApproveMoneyDepositRequest request)
        {
            
            if (ModelState.IsValid)
            {
                var response = new ResponseBase();
                var res = _moneyDepositService.ApproveMoneyDeposit(request);
                if (res == true)
                {
                    response.Status = true;
                }
                else
                {
                    response.Status = false;
                }

                return SendResult(response);
            }
            return BadRequest(ModelState);
        }

        [HttpPost(template:"create")]
        public IActionResult Create([FromBody]MoneyDepositModel moneyDeposit)
        {
            var response = new GenericResponseBase<MoneyDepositModel>();

            if (ModelState.IsValid)
            {
                var newDeposit = _moneyDepositService.CreateDeposit(moneyDeposit);
                if(newDeposit == null)
                {
                    response.Status = false;
                }
                else
                {
                    response.Status = true;
                    response.Response = newDeposit;
                }

                return SendResult(response);
            }
            return BadRequest(ModelState);
        }
    }
}