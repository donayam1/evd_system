using System;

namespace Vouchers.Data.Enumerations
{
    public enum VoucherStatusTypes
    {
        /// <summary>
        /// The voture is available and can be sold 
        /// </summary>
        Available = 0,
        Reserved = 10,

        Sold = 20,        
        Printed = 30
    }
}
