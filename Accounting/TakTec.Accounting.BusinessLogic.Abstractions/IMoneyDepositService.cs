using System;
using System.Collections.Generic;
using TakTec.Accounting.ViewModels;

namespace TakTec.Accounting.BusinessLogic.Abstractions
{
    public interface IMoneyDepositService
    {
        bool ApproveMoneyDeposit(ApproveMoneyDepositRequest request);
        MoneyDepositModel? CreateDeposit(MoneyDepositModel request);
        List<MoneyDepositModel> ListDeposits(ListMoneyDepositsRequest request);
    }
}
