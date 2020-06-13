using System;
using System.Collections.Generic;
using TakTec.Accounting.Entities;
using TakTec.Accounting.ViewModels;
using System.Linq;

namespace TakTec.Accounting.ObjectMappers
{
    public static class MoneyDepositMapper
    {
        public static MoneyDeposit ToDomainModel(this MoneyDepositModel model,
            String creatorUserId,String retailerPlanId,String ownerId) {
            MoneyDeposit deposit = new MoneyDeposit(creatorUserId,
                model.ForUserId, model.Amount, model.BankId, "",
                model.IsCheque, model.ReferanceNumber, retailerPlanId, ownerId,
                EthioArt.Data.Enumerations.ResourceTypes.GROUP)
            {

            };
            return deposit;
        }
        public static MoneyDepositModel ToViewModel(this MoneyDeposit deposit) {
            MoneyDepositModel res = new MoneyDepositModel()
            {
                Amount = deposit.Amount,
                Id = deposit.Id,
                BankId = deposit.BankId,
                ForUserId = deposit.ForUserId,
                IsCheque = deposit.IsCheque,
                ReferanceNumber = deposit.ReferanceNumber
            };
            return res;
        }

        public static List<MoneyDepositModel> ToViewModel(this List<MoneyDeposit> deposits) {
            return deposits.Select(x => x.ToViewModel()).ToList();
        }
    }
}
