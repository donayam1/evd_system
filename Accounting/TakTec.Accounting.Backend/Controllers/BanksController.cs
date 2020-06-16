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

namespace TakTec.Accounting.Backend.Controllers
{
    //[Route("api/accounting/[controller]")]
    [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName)]
    public class BanksController: AccountingControllersBase
    {
        private readonly IBankService _bankService;
        public BanksController(IUserMessageLogges userMessageLogges,IBankService bankService)
                             :base(userMessageLogges)
        {
            _bankService = bankService ?? throw new ArgumentNullException(nameof(IBankService));
        }

        [HttpGet(template:"list")]
        public IActionResult ListBanks([FromQuery]PagedItemRequestBase page)
        {
            if(ModelState.IsValid)
            {
                var bankList = new BanksListResponseViewModel();
                var banks = _bankService.ListBanks(page.ItemsPerPage,page.Page);
                if(banks == null)
                {
                    bankList.Status = false;
                }
                else
                {
                    bankList.Status = true;
                    bankList.Banks = banks;
                }

                return SendResult(bankList);           
            }

            return BadRequest(ModelState);
        }

        [HttpPost(template:"update")]
        public IActionResult Update([FromBody] BankViewModel bankViewModel)
        {
            if(ModelState.IsValid)
            {
                var bankResponse =  new BankResponseViewModel();
                var updatedBank = _bankService.Update(bankViewModel);
                if(updatedBank == null)
                {
                    bankResponse.Status = false;
                }
                else
                {
                    bankResponse.Status = true;
                    bankResponse.Bank = updatedBank;
                }

                return SendResult(bankResponse);
            }
            return BadRequest(ModelState);
        }

        [HttpPost(template:"create")]
        public IActionResult Create([FromBody] List<BankViewModel> newBanks)
        {
            if(ModelState.IsValid)
            {
                var newBanksResp = new NewBanksListResponse();
                var _newBanks = _bankService.CreateBanks(newBanks);
                if(_newBanks == null)
                {
                    newBanksResp.Status = false;
                }
                else
                {
                    newBanksResp.Status = true;
                    newBanksResp.NewBanks = _newBanks;
                }

                return SendResult(newBanksResp);
            }
            return BadRequest(ModelState);
        }
    }
}