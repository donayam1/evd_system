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
namespace TakTec.Accounting.BusinessLogic
{
    public class BankAccountsService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IStorage _storage;
        private readonly ILogger _logger;

        public BankAccountsService(IStorage storage, ILogger<IBankAccountService> logger)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _bankAccountRepository = _storage.GetRepository<IBankAccountRepository>() ??
                                     throw new ArgumentNullException(nameof(IBankAccountRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public BankAccountViewModel? CreateorUpdate(BankAccountViewModel bankAccountViewModel)
        {
            BankAccount bankAccount = bankAccountViewModel.ToDomain();
            if(!(ValidateBankAccount(bankAccount,bankAccountViewModel.Status)))
            {
                _logger.AddUserError("Invalid request!");
                return null;
            }

            BankAccount? _bankAccount;

            switch(bankAccountViewModel.Status)
            {
                case ObjectStatusEnum.NEW:
                    _bankAccount = Create(bankAccount);
                    break;
                case ObjectStatusEnum.EDITTED:
                    _bankAccount = Update(bankAccount);
                    break;
                case ObjectStatusEnum.REMOVED:
                    _bankAccount = Remove(bankAccount);
                    break;
                default:
                    return null;
            }

            if(_bankAccount != null)
            {
                try
                {
                    _storage.Save();
                }
                catch (Exception e)
                {
                    _logger.LogError(e.InnerException,e.Message);
                    _logger.AddUserError("Unknown error. please contact adminstrator");
                    return null;
                }
            }

            throw new NotImplementedException();
        }

        private bool ValidateBankAccount(BankAccount bankAccount, ObjectStatusEnum status)
        {
            BankAccount? bankAcct = _bankAccountRepository.WithAccountNumber(bankAccount.AccountNumber);

            if(status != ObjectStatusEnum.NEW)
            {
                bool exists = _bankAccountRepository.Exists(bankAccount.Id);
                if(!exists)
                {
                    _logger.AddUserError("Bank account does not exist");
                    return false;
                }
                if(bankAcct != null)
                {
                    _logger.AddUserError("Bank account with account number "+bankAccount.AccountNumber+" already exists");
                    return false;
                }

                else if(status == ObjectStatusEnum.NEW)
                {
                    if(bankAcct != null)
                    {
                        _logger.AddUserError("Bank account with account number "+bankAccount.AccountNumber+" already exists");
                        return false;
                    }
                }
            }
            return true;
        }

        private BankAccount Create(BankAccount bankAccount)
        {
            _bankAccountRepository.Create(bankAccount);
            return bankAccount;
        }
        private BankAccount? Update(BankAccount bankAccount)
        {
            BankAccount? bAccount = _bankAccountRepository.WithKey(bankAccount.Id);
            //perform updates
            bAccount.AccountNumber = bankAccount.AccountNumber;
        
            _bankAccountRepository.Edit(bAccount);
            return bAccount;
        }

        public BankAccount? Remove(BankAccount bankAccount)
        {
            return null;
        }
        public List<BankAccountViewModel> List(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }
    }
}