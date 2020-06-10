using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Accounting.ViewModels;

namespace TakTec.Accounting.BusinessLogic.Abstractions
{
    public interface IBankService
    {
        List<NewBankViewModel> CreateBanks(List<NewBankViewModel> NewBanks);
        BankViewModel Update(BankViewModel bank);
        List<BankViewModel> listBanks (int ItemsPerPage,int page);


    }
}
