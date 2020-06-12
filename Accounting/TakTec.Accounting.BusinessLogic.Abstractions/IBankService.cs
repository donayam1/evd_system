using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Accounting.ViewModels;

namespace TakTec.Accounting.BusinessLogic.Abstractions
{
    public interface IBankService
    {
        List<NewBankViewModel>? CreateBanks(List<BankViewModel> NewBanks);
        BankViewModel? Update(BankViewModel bank);
        List<BankViewModel> ListBanks (int ItemsPerPage,int page);


    }
}
