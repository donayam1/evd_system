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


        public List<NewBankViewModel>? CreateBanks(List<BankViewModel> newBanks)
        {
            //List<Bank> banks = newBanks.Select(x=>x.ToBankDomainModel()).ToList();
            foreach(BankViewModel b in newBanks)
            {
                if(!ValidateBank(b))
                {
                    _logger.AddUserError("Invalid request!");
                    return null;
                }
            }
            

           // var _banks = banks.Select(x=>Create(x)).ToList();
           List<Bank> _banks = new List<Bank>();
           foreach (var item in newBanks)
           {
               var bank = Create(item);
                _banks.Add(bank);
           }

            //List<NewBankViewModel>? newBanksVm = new List<NewBankViewModel>();
                           

            //foreach (var item in _banks)
            //{
            //   newBanksVm.Add((NewBankViewModel)item.ToBankViewModel());
            //}

            try
            {
                _storage.Save();
                return _banks.ToNewBankViewModel(); //TODO add the UI_IDs here 
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException, e.Message);
                _logger.AddUserError("Unknown error. Please contact adminstrator");
                return null;
            }


            //return SaveBanks(_banks)== true ? newBanksVm : null;

        }
        
        private Bank Create(BankViewModel bank)
        {
            var tBank = bank.ToBankDomainModel();
            _bankRepository.Create(tBank);
            return tBank;
        }


        public List<BankViewModel> ListBanks(int ItemsPerPage, int page)
        {
           var items =  _bankRepository.GetCustomFilters(page,ItemsPerPage).Items.ToList();
            return items.ToBankDomainList();
        }

        public BankViewModel? Update(BankViewModel bankVm)
        {
            //Bank _bank = bankVm.ToBankDomainModel();
            if (!ValidateBank(bankVm))
            {
                _logger.AddUserError("Invalid request!");
                return null;
            }

            var bank = _bankRepository.WithKey(bankVm.Id);
            bank.Name = bankVm.Name;

            try
            {
                _storage.Save();
                return bank.ToBankViewModel();
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException, e.Message);
                _logger.AddUserError("Unknown error. Please contact adminstrator");
                return null;
            }

        }


        private bool ValidateBank(BankViewModel bank)
        {
            Bank? _bank = _bankRepository.WithName(bank.Name);
            if (_bank != null)
            {
                _logger.AddUserError("Bank with name" + _bank.Name + " already exists!");
                return false;
            }
            if (bank.Status != ObjectStatusEnum.NEW)
            {
                bool exists = _bankRepository.Exists(bank.Id);
                if(exists==false)
                {
                    _logger.AddUserError("Bank does not exist!");
                    return false;
                }
                
            }

            else if(bank.Status == ObjectStatusEnum.NEW)
            {
                //if(_bank!=null)
                //{
                //    _logger.AddUserError("Bank with name"+_bank.Name+" already exists!");
                //    return false;
                //}
            }
            return true;
        }

        //private bool SaveBanks(List<Bank> banks)
        //{ 
        //    foreach(Bank b in banks)
        //    {
        //        Create(b);
        //    }

        //    try
        //    {
        //        _storage.Save();
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e.InnerException, e.Message);
        //        _logger.AddUserError("Unknown error. Please contact adminstrator");
        //        return false;
        //    }


        //    return true;
        //}
    }
}