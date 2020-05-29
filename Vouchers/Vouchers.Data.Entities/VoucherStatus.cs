using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Vouchers.Data.Entities;
using Vouchers.Data.Enumerations;

namespace Vouchers.Data.Entities
{
    public class VoucherStatus:EntityBase 
    {
        public VoucherStatus(String voucherId,VoucherStatusTypes status) : 
            base("",ResourceTypes.NONE) // Make this voture
        {
            this.Status = status;
            this.VoucherId = voucherId;            
        }

        public String VoucherId { get; set; }
        public VoucherStatusTypes Status { get; set; }
        public Boolean IsCurrent { get; set; } = true;


        [ForeignKey(nameof(VoucherId))]
        public Voucher? Voucher { get; set; }

    }
}
