﻿using EthioArt.Backend.Models.Requests;
using System;
using System.Collections.Generic;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic.Abstractions
{
    public interface IVoucherService
    {
        /// <summary>
        /// Returns Pages List of votures for the current user
        /// </summary>
        public List<VoucherModel> ListVoutchers(PagedItemRequestBase request);
        
        /// <summary>
        /// Updates a Voutcher. Chages its status 
        /// make it sold, used, or reserved
        /// </summary>
        public void UpdateVoutcher();




    }
}
