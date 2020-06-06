using EthioArt.Data.Entities.Abstraction;
using EthioArt.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vouchers.Data.Entities
{
    public class Voucher:EntityBase 
    {
        public Voucher(String batchId, int serialNumber,
            int pinNumber) :base("",ResourceTypes.SITE) {
            this.BatchId = batchId;
            
            this.SerialNumber = serialNumber;
            this.PinNumber = pinNumber;            
        }

        public String BatchId { get; set; }
        public int SerialNumber { get; set; }        
        public int PinNumber { get; set; }

        /// <summary>
        /// Indicates the voucher is free and available in the system pull 
        /// </summary>
        public bool IsInSystemPool { get; set; } = true;

        [ForeignKey(nameof(BatchId))]
        public VoucherBatch? Batch { get; set; }
        public List<VoucherStatus> VoucherStatuses { get; set; } = new List<VoucherStatus>();

        public List<UserVoucher> UserVouchers { get; set; } = new List<UserVoucher>();

    }
}
