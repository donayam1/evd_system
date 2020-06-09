using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TakTec.Accounting.Entities
{
    public class MoneyDeposit:EntityBase 
    {
        public MoneyDeposit(String creatorUserId,
            String forUserId,
            decimal amount,
            String bankId,
            String? fromAccountId, // It might be check
            bool isCheque,
            String referanceNumber,
            String retailerPlanId,
            String ownerId,
            ResourceTypes ownerType) 
            : base(ownerId,ownerType) {

            //this.FromUserRoleName = fromUserRoleName;
            this.CreatorUserId = creatorUserId;
            this.ForUserId = forUserId;
            this.Amount = amount;
            this.BankId = bankId;
            this.FromAccountId = fromAccountId;
            this.ReferanceNumber = referanceNumber;
            this.RetailerPlanId = retailerPlanId;
            this.IsCheque = isCheque;
        }


        //public String FromUserRoleName { get; set; }
        public String ForUserId { get; set; }        
        public decimal Amount { get; set; }
        public String BankId { get; set; }
        public String? FromAccountId { get; set; }
        public String ReferanceNumber { get; set; }
        public String RetailerPlanId { get; set; }
        public Boolean IsCheque { get; set; }

        [ForeignKey(nameof(BankId))]
        public Bank? Bank { get; set; } = default!;
        public List<MoneyDepositRollbackRequest> MoneyDepositRollbackRequests { get; set; } = 
            new List<MoneyDepositRollbackRequest>();

    }
}
