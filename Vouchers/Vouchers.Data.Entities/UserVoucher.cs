using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vouchers.Data.Entities
{
    /// <summary>
    /// This represents all the voters bought by a specefied user 
    /// </summary>
    public class UserVoucher:EntityBase 
    {
        public UserVoucher(String ownerId,String voucherId) : 
            base(ownerId, ResourceTypes.GROUP) {
            this.VoucherId = voucherId;   
        }

        public String VoucherId { get; set; }

        /// <summary>
        /// This filed show the current status of Voucher,
        /// e.g. if a sub-disributor reserves a Voucher the he sells it
        /// to a distributor we will mark through which user it has been
        /// sent to a retailer. This indicates if this is the current state 
        /// of the voucher.  
        /// </summary>
        public Boolean IsCurrent { get; set; } = true;


        [ForeignKey(nameof(VoucherId))]
        public Voucher? Voucher { get; set; }

    }
}
