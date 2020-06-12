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
        public static BankAccount ToDomain(this BankAccountViewModel bankAccountViewModel,string ownerId)
        {
            BankAccount bankAccount = new BankAccount(bankAccountViewModel.BankId,
                bankAccountViewModel.Id,ownerId);
            return bankAccount;
        }

        public static BankAccountViewModel ToViewModel(this BankAccount bankAccount)
        {
            BankAccountViewModel _bankAccount = new BankAccountViewModel() {
                AccountNumber = bankAccount.AccountNumber,
                BankId = bankAccount.BankId,
                Id = bankAccount.Id,
                Status = ObjectStatusEnum.UNCHANGED,
                UserId = bankAccount.OwnerId //TOOD make this the user id

            };
            return _bankAccount;
        }
        public static NewBankAccountViewModel ToNewBankAccountViewModel(this BankAccount bankAccount,string ui_id)
        {
            NewBankAccountViewModel _bankAccount = new NewBankAccountViewModel()
            {
                UI_Id = ui_id,
                AccountNumber = bankAccount.AccountNumber,
                BankId = bankAccount.BankId,
                Id = bankAccount.Id,
                Status = ObjectStatusEnum.UNCHANGED,
                UserId = bankAccount.OwnerId //TOOD make this the user id 
            };
            return _bankAccount;
        }

        public static List<BankAccountViewModel> ToListViewModels(this List<BankAccount> bankAccounts)
        {
            return bankAccounts.Select(x=>x.ToViewModel()).ToList();
        }
    }
}