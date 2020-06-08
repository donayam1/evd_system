using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
using System;

namespace TakTec.Accounting.Entities
{
    public class MoneyDeposit:EntityBase 
    {
        public MoneyDeposit(String fromUserRoleName,
            String forUserRoleName,
            decimal amount,
            String bankId,
            String fromAccountId,
            String referanceId,
            String ownerId,
            ResourceTypes ownerType) 
            : base(ownerId,ownerType) {

            this.FromUserRoleName = fromUserRoleName;
            this.ForUserRoleName = forUserRoleName;
            this.Amount = amount;
            this.BankId = bankId;
            this.FromAccountId = fromAccountId;
            this.ReferanceId = referanceId;
        }

        public String FromUserRoleName { get; set; }
        public String ForUserRoleName { get; set; }        
        public decimal Amount { get; set; }
        public String BankId { get; set; }
        public String FromAccountId { get; set; }
        public String ReferanceId { get; set; }

    }
}
