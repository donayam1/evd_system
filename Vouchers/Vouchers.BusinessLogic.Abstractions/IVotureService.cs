using EthioArt.Backend.Models.Requests;
using System;
using System.Collections.Generic;
using Vouchers.Shared.ViewModels;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic.Abstractions
{
    public interface IVoucherService
    {
        /// <summary>
        /// Returns Pages List of votures for the current user
        /// </summary>
        public List<VoucherModel> ListVoutchers(ListVoucherRequest request);
        bool AreVouchersAvailable(VoucherTransferRequest request, String fromUserRoleName);
        bool TransferVouchersToUser(VoucherTransferRequest request, String fromUserRoleName, String toUserRole);

        /// <summary>
        /// Updates a Voutcher. Chages its status 
        /// make it sold, used, or reserved
        /// </summary>
        //public void UpdateVoutcher();




    }
}
