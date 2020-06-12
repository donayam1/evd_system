using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Accounting.ViewModels;

namespace TakTec.Accounting.BusinessLogic.Abstractions
{
    public interface IBankAccountService
    {
        BankAccountViewModel? CreateOrUpdate(BankAccountViewModel bankAccountViewModel);
        List<BankAccountViewModel> List(ListBankAccountsRequest request);   
    } 
}