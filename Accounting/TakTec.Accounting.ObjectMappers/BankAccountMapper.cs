using System.Linq;
using TakTec.Accounting.Entities;
using TakTec.Accounting.ViewModels;
using EthioArt.Data.Enumerations;
using TakTec.Accounting.Enumerations;
using System.Collections.Generic;

namespace TakTec.Accounting.ObjectMappers
{
    public static class BankAccountMapper
    {
        public static BankAccount ToDomain(this BankAccountViewModel bankAccountViewModel)
        {
            BankAccount bankAccount = new BankAccount(bankAccountViewModel.BankId,bankAccountViewModel.Id,ResourceTypes.GROUP.ToString());
            return bankAccount;
        }

        public static BankAccountViewModel ToViewModel(this BankAccount bankAccount)
        {
            BankAccountViewModel _bankAccount = new BankAccountViewModel();
            return _bankAccount;
        }

        public static List<BankAccountViewModel> ToListViewModels(this List<BankAccount> bankAccounts)
        {
            return bankAccounts.Select(x=>x.ToViewModel()).ToList();
        }
    }
}