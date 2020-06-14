using EthioArt.Backend.Models.Requests;
using System;
using System.Collections.Generic;
using Vouchers.Data.Entities;
using Vouchers.Shared.ViewModels;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic.Abstractions
{
    public interface IVoucherService
    {
        List<VoucherStatistics> GetFreeSystemAvailabelDenominations();
        List<VoucherStatistics> GetVoucherStatistics();
        /// <summary>
        /// Returns Pages List of votures for the current user
        /// </summary>
        public List<VoucherModel> ListVoutchers(ListVoucherRequest request);
        public List<VoucherModel>? CheckOutVoutchers(ListVoucherRequest request);
        bool AreVouchersAvailable(VoucherTransferRequest request, String fromUserRoleName, String buyerUserRoleName);
        List<Voucher>? TransferVouchersToUser(VoucherTransferRequest request,  String toUserRole);//String fromUserRoleName,
        VoucherBatch? GetBatch(String id);

        /// <summary>
        /// Updates a Voutcher. Chages its status 
        /// make it sold, used, or reserved
        /// </summary>
        //public void UpdateVoutcher();


        VoucherModel? CheckOutVoucher(CheckOutVoucherRequest request);

    }
}
