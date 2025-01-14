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
    public class BankAccountsController: AccountingControllersBase
    {
        private readonly IBankAccountService _bankAccountService;
        public BankAccountsController(IUserMessageLogges userMessageLogges,IBankAccountService bankAccountService)
                             :base(userMessageLogges)
        {
            _bankAccountService = bankAccountService ?? throw new ArgumentNullException(nameof(IBankService));
        }

        [HttpGet(template:"list")]
        public IActionResult List([FromQuery]ListBankAccountsRequest request)
        {
            if(ModelState.IsValid)
            {
                var bankAccountList = new BankAccountListResponse();
                var bankAccounts = _bankAccountService.List(request);
                if(bankAccounts == null)
                {
                    bankAccountList.Status = false;
                }
                else
                {
                    bankAccountList.Status = true;
                    bankAccountList.BankAccounts = bankAccounts;
                }

                return SendResult(bankAccountList);           
            }

            return BadRequest(ModelState);
        }

        [HttpPost(template:"update")]
        public IActionResult Update([FromBody] BankAccountViewModel bankAccountViewModel)
        {
            if(ModelState.IsValid)
            {
                var resp =  new BankAccountResponseModel();
                var updatedBankAccount = _bankAccountService.CreateOrUpdate(bankAccountViewModel);
                if(updatedBankAccount == null)
                {
                    resp.Status = false;
                }
                else
                {
                    resp.Status = true;
                    resp.BankAccount = updatedBankAccount;
                }

                return SendResult(resp);
            }
            return BadRequest(ModelState);
        }

        [HttpPost(template:("create"))]
        public IActionResult Create([FromBody] BankAccountViewModel newBankAccount)
        {
            if(ModelState.IsValid)
            {
                var response = new NewBankAccountResponse();
                var newBankAccnt = _bankAccountService.CreateOrUpdate(newBankAccount);
                if(newBankAccnt == null)
                {
                    response.Status = false;
                }
                else
                {
                    response.Status = true;
                    response.NewBankAccount = (NewBankAccountViewModel?)newBankAccnt;
                }

                return SendResult(response);
            }
            return BadRequest(ModelState);
        }
    }
}