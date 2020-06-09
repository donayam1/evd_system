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


        public List<NewBankViewModel> CreateBanks(List<BankViewModel> newBanks)
        {
            // List<Bank> banks = newBanks.ToBankDomainList();
            // foreach(Bank b in banks)
            // {
            //     if(!ValidateBank(b,ObjectStatusEnum.NEW))
            //     {
            //         _logger.AddUserError("Invalid request!");
            //         break;
            //     }
            // }



            throw new NotImplementedException();

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

        public BankViewModel Update(BankViewModel bank)
        {
            // Bank _bank = bank.ToBankDomainModel();
            // if(!ValidateBank(_bank,bank.Status))
            // {
            //     _logger.AddUserError("Invalid request!");
            //     return null;
            // }


            throw new NotImplementedException();
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
    }
}