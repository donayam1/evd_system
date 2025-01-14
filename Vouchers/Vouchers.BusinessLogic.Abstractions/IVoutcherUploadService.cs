﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic.Abstractions
{
    public interface IVoucherUploadService
    {
        /// <summary>
        /// This function is supposed to watch the voucher's upload 
        /// directory and decrypt, verify and insert the upload voucher to the system
        /// database 
        /// </summary>
        public void ScheduleUploadedVoucherFileProcessor(UploadedFile file);

    }
}
