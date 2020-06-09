using System;
using TakTec.Accounting.ViewModels;

namespace TakTec.Accounting.BusinessLogic.Abstractions
{
    public interface IMoneyDepositService
    {
        bool ApproveMoneyDeposit(ApproveMoneyDepositRequest request);
    }
}
