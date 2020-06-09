using EthioArt.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Accounting.Enumerations;

namespace TakTec.Accounting.Entities
{
    public class AirTimeUpdate:EntityBase 
    {
        public AirTimeUpdate(AirTimeUpdateCauseType airTimeUpdateCauseType,
            String airTimeUpdateCauseId,
            Decimal amount,
            String ownerId) :
            base(ownerId, EthioArt.Data.Enumerations.ResourceTypes.GROUP)
        {
            this.AirTimeUpdateCauseType = airTimeUpdateCauseType;
            this.AirTimeUpdateCauseId = airTimeUpdateCauseId;
            this.Amount = amount;
        }

        public AirTimeUpdateCauseType AirTimeUpdateCauseType { get; set; }
        public String AirTimeUpdateCauseId { get; set; }        
        public Decimal Amount { get; set; }
        

    }
}
