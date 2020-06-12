using System;
using System.Linq;
using System.Collections.Generic;
using TakTec.Accounting.BusinessLogic.Abstractions;
using TakTec.Accounting.ViewModels;
using EthioArt.Data.Enumerations;
using ExtCore.Data.Abstractions;
using Messages.Logging.Extensions;
using Microsoft.Extensions.Logging;
using TakTec.Accounting.Data.Abstractions;
using TakTec.Accounting.Entities;
using TakTec.Accounting.ObjectMappers;
using EthioArt.Filters.Abstraction;
using EthioArt.Data.Entities;
using EthioArt.Sorters.Abstractions;
using EthioArt.UserAccounts.Services.Abstractions;

namespace TakTec.Accounting.BusinessLogic
{
    public class BankAccountsService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IStorage _storage;
        private readonly ILogger _logger;
        private readonly IAccountService _accountService;

        public BankAccountsService(IStorage storage, ILogger<IBankAccountService> logger,
            IAccountService accountService)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _bankAccountRepository = _storage.GetRepository<IBankAccountRepository>() ??
                                     throw new ArgumentNullException(nameof(IBankAccountRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _accountService = accountService ?? throw new ArgumentNullException(nameof(IAccountService));
        }

        public BankAccountViewModel? CreateOrUpdate(BankAccountViewModel bankAccountViewModel)
        {
            if(!ValidateBankAccount(bankAccountViewModel))
            {
                _logger.AddUserError("Invalid request!");
                return null;
            }
            var user = _accountService.GetUser(bankAccountViewModel.UserId);
            if (user == null) {
                return null;
            }
            String userRole = user.AspNetUserRoles.FirstOrDefault().AspNetRole.Name; //TODO do a null check.
            BankAccount? _bankAccount;

            switch(bankAccountViewModel.Status)
            {
                case ObjectStatusEnum.NEW:
                    _bankAccount = Create(bankAccountViewModel,userRole);
                    break;
                case ObjectStatusEnum.EDITTED:
                    _bankAccount = Update(bankAccountViewModel);
                    break;
                case ObjectStatusEnum.REMOVED:
                    _bankAccount = Remove(bankAccountViewModel);
                    break;
                default:
                    return null;
            }
            
            if(_bankAccount != null)
            {
                try
                {
                    _storage.Save();
                    return _bankAccount.ToNewBankAccountViewModel(bankAccountViewModel.Id);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.InnerException,e.Message);
                    _logger.AddUserError("Unknown error. please contact adminstrator");                    
                }
            }

            return null;

        }

        private bool ValidateBankAccount(BankAccountViewModel bankAccount)
        {
            

            BankAccount? bankAcct = _bankAccountRepository.WithAccountNumber(bankAccount.AccountNumber, bankAccount.BankId);
            if (bankAcct != null)
            {
                _logger.AddUserError("Bank account with account number " + bankAccount.AccountNumber + " already exists");
                return false;
            }
            if (bankAccount.Status != ObjectStatusEnum.NEW)
            {
                bool exists = _bankAccountRepository.Exists(bankAccount.Id);
                if(!exists)
                {
                    _logger.AddUserError("Bank account does not exist");
                    return false;
                }
                
                else if(bankAccount.Status == ObjectStatusEnum.NEW)
                {
                    //if(bankAcct != null)
                    //{
                    //    _logger.AddUserError("Bank account with account number "+bankAccount.AccountNumber+" already exists");
                    //    return false;
                    //}
                }
            }
            return true;
        }

        private BankAccount Create(BankAccountViewModel bankAccount,String ownerId)
        {
            BankAccount ba = bankAccount.ToDomain(ownerId);
            _bankAccountRepository.Create(ba);
            return ba;
        }
        private BankAccount? Update(BankAccountViewModel bankAccount)
        {
            BankAccount? bAccount = _bankAccountRepository.WithKey(bankAccount.Id);
            //perform updates
            bAccount.AccountNumber = bankAccount.AccountNumber;
        
            _bankAccountRepository.Edit(bAccount);
            return bAccount;
        }

        public BankAccount? Remove(BankAccountViewModel bankAccount)
        {
            return null;
        }

        public List<BankAccountViewModel> List(ListBankAccountsRequest request)
        {
            var user = _accountService.GetUser(request.UserId);
            if (user == null) {
                return new List<BankAccountViewModel>();
            }
            String roleName = user.AspNetUserRoles.FirstOrDefault().AspNetRole.Name;
            return this._bankAccountRepository.WithOwnerItemId(roleName).ToList().ToListViewModels();
        }
    }
}
