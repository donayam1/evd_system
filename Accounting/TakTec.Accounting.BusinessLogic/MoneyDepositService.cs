﻿using ExtCore.Data.Abstractions;
using System;
using TakTec.Accounting.Data.Abstractions;
using TakTec.Accounting.ViewModels;

namespace TakTec.Accounting.BusinessLogic
{
    public class MoneyDepositService
    {
        private readonly IMoneyDepositRepository _moneyDepositRepository;
        private readonly IStorage _storage;
        public MoneyDepositService(IStorage storage) {
            _storage = storage ?? throw new ArgumentNullException(nameof(IStorage));
            _moneyDepositRepository = storage.GetRepository<IMoneyDepositRepository>();
        }


        bool validateApproveReqeust() {
            return false;
        }

        public bool ApproveMoneyDeposit(ApproveMoneyDepositRequest request) {

            return false;
        }

    }
}
