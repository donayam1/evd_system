using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Accounting.ViewModels;

namespace TakTec.Accounting.BusinessLogic.Abstractions
{
    public interface IBankAccountService
    {
        BankAccountViewModel CreateorUpdate(BankAccountViewModel bankAccountViewModel);
        List<BankAccountViewModel> List(int page, int itemsPerPage);   
    } 
}