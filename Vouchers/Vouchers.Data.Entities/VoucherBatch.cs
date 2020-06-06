using EthioArt.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;

namespace Vouchers.Data.Entities
{
    public class VoucherBatch:EntityBase 
    {
        public VoucherBatch(
            String purchaserOrderId,
            String batch,
            DateTime stopDate,
            int startSequence,
            int quantity,
            float denomination
            ) :base("",EthioArt.Data.Enumerations.ResourceTypes.SITE) {
            this.PurchaserOrderId = purchaserOrderId;
            this.Batch = batch;
            this.StopDate = stopDate;
            this.StartSequence = startSequence;
            this.Quantity = quantity;
            this.Denomination = denomination;
        }

        /// <summary>
        /// The purchase order number from the incomming 
        /// voture file.
        /// 
        /// The external purchase order number under with this batch 
        /// was bought 
        /// 
        /// TODO, chage it to purchase order Id
        /// </summary>
        public String PurchaserOrderId { get; set; }

        /// <summary>
        /// The batch number from the incomming voture file 
        /// </summary>
        public String Batch { get; set; }

        /// <summary>
        /// Expiration date
        /// </summary>
        public DateTime StopDate { get; set; }
        
        /// <summary>
        /// The start serial number of this batch 
        /// </summary>
        public int StartSequence { get; set; }

        /// <summary>
        /// The total number of pins in this Voter 
        /// </summary>
        public int Quantity { get; set; }

        public float Denomination { get; set; }

        /// <summary>
        /// The id of the key used to encrypt and store the voture numbers 
        /// locally in the database. This key will be generated for each incomming batch 
        /// 
        /// Note. I dont really see the need for encrypting the voters in the database.
        /// because a person who has acess to the database will be abel to find the decryption key too.
        /// But encrypting them will some how slow him down 
        /// 
        /// </summary>
        public String? EncryptionKeyId { get; set; }

        public List<Voucher> Vouchers { get; set; } = new List<Voucher>();

        
    }
}
