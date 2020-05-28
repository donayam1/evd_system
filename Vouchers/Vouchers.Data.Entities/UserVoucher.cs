using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Voters.Data.Entities
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
        

    }
}
