using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Voters.Data.Entities
{
    /// <summary>
    /// A retailer can request a sub distributor to re-transmit a voture if he pays for it 
    /// and did not recive the voture. In this case the sub distributor will search and mark the voture 
    /// ready for re transmission. This table contains those marked votures and we will send them
    /// to the retailer when the minWaitMinutes time reaches above the created date time 
    /// </summary>
    public class VotureMarkedForReTransmit : EntityBase 
    {
        public VotureMarkedForReTransmit(String voterId,
            int minWaitMinutes) :
            base("",ResourceTypes.GROUP) {
            this.VoterId = voterId;
            this.MinWaitMinutes = minWaitMinutes;
        }

        public String VoterId { get; set; }
        /// <summary>
        /// Weight at least this much minuest before sending this
        /// pin along with the users Sync pins request 
        /// </summary>
        public int MinWaitMinutes { get; set; }

        [ForeignKey(nameof(VoterId))]
        public Voucher? Voter { get; set; }


    }
}
