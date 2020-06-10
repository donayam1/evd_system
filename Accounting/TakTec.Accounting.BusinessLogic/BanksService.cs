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
    public class BanksService : IBankService
    {
        private readonly IBankRepository _bankRepository;
        private readonly ILogger<IBankService> _logger;
        private readonly IStorage _storage;

        public BanksService(IStorage storage,ILogger<IBankService>logger)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bankRepository = _storage.GetRepository<IBankRepository>() ??
                            throw new ArgumentNullException(nameof(IBankRepository));   
        }


        public List<NewBankViewModel>? CreateBanks(List<NewBankViewModel> newBanks)
        {
            List<Bank> banks = newBanks.Select(x=>x.ToBankDomainModel()).ToList();
            foreach(Bank b in banks)
            {
                if(!ValidateBank(b,ObjectStatusEnum.NEW))
                {
                    _logger.AddUserError("Invalid request!");
                    return null;
                }
            }

            var _banks = banks.Select(x=>Create(x)).ToList();

            var newBanksVm = _banks.Select(x=>     
                           (NewBankViewModel)x.ToBankViewModel())
                           .ToList();
           
            return SaveBanks(_banks)== true ? newBanksVm : null;

        }
        
        private Bank Create(Bank bank)
        {
            _bankRepository.Create(bank);
            return bank;
        }


        public List<BankViewModel> listBanks(int ItemsPerPage, int page)
        {
           var items =  _bankRepository.GetCustomFilters(page,ItemsPerPage).Items.ToList();
            return items.ToBankDomainList();
        }

        public BankViewModel Update(BankViewModel bankVm)
        {
            Bank _bank = bankVm.ToBankDomainModel();
            if(!ValidateBank(_bank,bankVm.Status))
            {
                _logger.AddUserError("Invalid request!");
                return null;
            }

            var bank = _bankRepository.WithKey(_bank.Id);
            bank.Name = _bank.Name;
            
            return bank.ToBankViewModel();
        }


        private bool ValidateBank(Bank bank, ObjectStatusEnum status)
        {
            Bank _bank = _bankRepository.WithName(bank);
            if(status != ObjectStatusEnum.NEW)
            {
                bool exists = _bankRepository.Exists(bank.Id);
                if(exists==false)
                {
                    _logger.AddUserError("Bank does not exist!");
                    return false;
                }
                if(_bank!=null)
                {
                    _logger.AddUserError("Bank with name"+_bank.Name+" already exists!");
                    return false;
                }
            }

            else if(status == ObjectStatusEnum.NEW)
            {
                if(_bank!=null)
                {
                    _logger.AddUserError("Bank with name"+_bank.Name+" already exists!");
                    return false;
                }
            }
            return true;
        }

        private bool SaveBanks(List<Bank> banks)
        { 
            foreach(Bank b in banks)
            {
                try
                {
                    _storage.Save();
                }
                catch(Exception e)
                {
                    _logger.LogError(e.InnerException,e.Message);
                    _logger.AddUserError("Unknown error. Please contact adminstrator");
                    return false;
                }
            }
            
            return true;
        }
    }
}