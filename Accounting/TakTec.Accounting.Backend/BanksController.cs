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

namespace TakTec.Accounting.Backend
{
    [Route("api/accounting/[controller]")]
    public class BanksController:ControllersBase
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
            var bankList = new BanksListResponseViewModel();
            if(ModelState.IsValid)
            {
                var banks = _bankService.listBanks(page.ItemsPerPage,page.Page);
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
            var bankResponse =  new BankResponseViewModel();
            if(ModelState.IsValid)
            {
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

        [HttpPost(template:("create"))]
        public IActionResult Create([FromBody] List<NewBankViewModel> newBanks)
        {
            var newBanksResp = new NewBanksListResponse();
            if(ModelState.IsValid)
            {
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