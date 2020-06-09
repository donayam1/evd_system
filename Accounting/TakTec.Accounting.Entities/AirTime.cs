using EthioArt.Data.Entities.Abstraction;
using EthioArt.Syncronization.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakTec.Accounting.Entities
{
    public class AirTime:EntityBase , ILocable 
    {
        public AirTime(String ownerId,Decimal amount) : 
            base(ownerId,EthioArt.Data.Enumerations.ResourceTypes.GROUP) {

            this.Amount = amount;
        }

        public Decimal Amount { get; set; }

        public string GetLockId()
        {
            return Id;
        }
    }
}
