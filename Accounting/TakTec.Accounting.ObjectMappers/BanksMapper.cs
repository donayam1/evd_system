using System.Linq;
using System.Collections.Generic;
using TakTec.Accounting.Entities;
using TakTec.Accounting.ViewModels;
using EthioArt.Data.Enumerations;

namespace TakTec.Accounting.ObjectMappers
{
    public static class BanksMapper
    {
        public static Bank ToBankDomainModel(this BankViewModel bankVM)
        {
            //add other props
            var bank = new Bank(bankVM.Name);
            return bank;
        }
        
        public static BankViewModel ToBankViewModel(this Bank bank)
        {
            var bankVM = new BankViewModel
            {
                Id = bank.Id,
                Name = bank.Name
            };
            //add status
            return bankVM;
        }
        public static List<BankViewModel> ToBankViewModel(this List<Bank> banks)
        {
            return banks.Select(x => x.ToBankViewModel()).ToList();
        }
        public static NewBankViewModel ToNewBankViewModel(this Bank bank,string ui_id)
        {
            var bank2 = new NewBankViewModel()
            {
                Id = bank.Id,
                Name = bank.Name,
                Status = ObjectStatusEnum.UNCHANGED,
                UI_Id = ui_id
            };
            return bank2;
        }

        public static List<NewBankViewModel> ToNewBankViewModel(this List<Bank> banks)
        {
            return banks.Select(x => x.ToNewBankViewModel(x.Id)).ToList();
        }


        public static Bank ToBankDomainModel(NewBankViewModel newBank)
        {
            Bank bank = new Bank(newBank.Name);
            return bank; 
        }
        public static List<Bank> ToBankDomainList(this List<BankViewModel> bankVms)
        {
            List<Bank> banks = bankVms.Select(x=> x.ToBankDomainModel()).ToList();
            return banks;
        }

        public static List<BankViewModel> ToBankDomainList(this List<Bank> banks)
        {
            List<BankViewModel> bankVms = banks.Select(x=> x.ToBankViewModel()).ToList();
            return bankVms;
        }
        

        
    }
}