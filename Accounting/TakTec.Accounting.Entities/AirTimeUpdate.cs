using EthioArt.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TakTec.Accounting.Enumerations;

namespace TakTec.Accounting.Entities
{
    public class AirTimeUpdate:EntityBase 
    {
        public AirTimeUpdate(AirTimeUpdateCauseType airTimeUpdateCauseType, //String airTimeId,
            String airTimeUpdateCauseId,
            Decimal amount,
            bool isCredit,
            String ownerId) :
            base(ownerId, EthioArt.Data.Enumerations.ResourceTypes.GROUP)
        {
            this.AirTimeUpdateCauseType = airTimeUpdateCauseType;
            this.AirTimeUpdateCauseId = airTimeUpdateCauseId;
            this.Amount = amount;
            this.IsCredit = isCredit;
            //this.AirTimeId = airTimeId;
        }

        public AirTimeUpdateCauseType AirTimeUpdateCauseType { get; set; }
        public String AirTimeUpdateCauseId { get; set; }        
        public Decimal Amount { get; set; }
        //public String AirTimeId { get; set; }
        public Boolean IsCredit { get; set; }


        private AirTime? _airTime;
        [ForeignKey(nameof(OwnerId))]
        public AirTime AirTime
        {
            get
            {
                return _airTime ?? throw new InvalidOperationException($"Navigation property {nameof(_airTime)} is null.");
            }
            set
            {
                _airTime = value;

            }
        }

    }
}
