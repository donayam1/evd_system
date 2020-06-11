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
        public VoucherStatus(String ownerId, VoucherStatusTypes status) : 
            base(ownerId,ResourceTypes.NONE) // Make this voture
        {
            this.Status = status;
        }
        public VoucherStatusTypes Status { get; set; }
        public Boolean IsCurrent { get; set; } = true;


        private Voucher? _voucher;

        [ForeignKey(nameof(OwnerId))]
        public Voucher Voucher
        {
            get
            {
                return _voucher ?? throw new InvalidOperationException($"{nameof(_voucher)} is null");
            }
            set { _voucher = value; }
        }

    }
}
