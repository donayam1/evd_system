using EthioArt.Backend.Models.Requests;
using ExtCore.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.Data.Abstractions;
using Vouchers.ViewModels;
using Vouchers.ObjectMapper;
using Users.BusinessLogic.Abstraction;
using EthioArt.Extensions.DateTimeExtensions;
using Vouchers.Data.Entities;
using Microsoft.Extensions.Logging;
using Messages.Logging.Extensions;

namespace Vouchers.BusinessLogic
{
    public class VoucherService : IVoucherService
    {
        private readonly IStorage _storage;
        private readonly IUserVoucherRepository  _userVoucherRepository;
        private readonly ITokenUserService _tokenUserService;
        private readonly ILogger<IVoucherService> _logger;
        public VoucherService(IStorage storage,
            ITokenUserService tokenUserService,
            ILogger<IVoucherService> logger) {
            _storage = storage ?? 
                throw new ArgumentNullException(nameof(IStorage));
            _userVoucherRepository = _storage.GetRepository<IUserVoucherRepository>() ??
                throw new ArgumentNullException(nameof(IUserVoucherRepository));
            _tokenUserService = tokenUserService ??
                throw new ArgumentNullException(nameof(tokenUserService));
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger<IVoucherService>));
        }

        public List<VoucherModel> ListVoutchers(ListVoucherRequest request)
        {
            String role = _tokenUserService.UserRole;
            return _userVoucherRepository.WithOwnerItemId(role,true,request.IsSyncing,
                request.FromDate.FromSharedDateTimeString(),
                request.ToDate.FromSharedDateTimeString()).
                Select(x=>x.Voucher).OrderBy(x=>x.DatabaseAddedDateTime).
                ToList().
                ToViewModel();
        }


        public bool AreVouchersAvailable(VoucherTransferRequest request, String fromUserRoleName) {
            foreach (var v in request.TransferRequestItems) {
                if (_userVoucherRepository.CountUserFreeVouchers(fromUserRoleName, v.Denomination, v.Quantity) < v.Quantity) {
                    _logger.AddUserError($"{v.Quantity} vouchers of {v.Denomination} birr not avaiable.");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The methods looks for free vouchers stoked by the fromUserRoleName and
        /// if there are available vouchers it  will transfer them to the toUserRole
        /// 
        /// if the formUserRoleName has no enough vouchers the algorithm will look
        /// for free vouchers from the system and transfer them to the user.
        /// 
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="fromUserRoleName">This is the distributor who is selling the vouchers</param>
        /// <param name="toUserRole">This is the distributor who is reciving the vouchers</param>
        /// <returns></returns>
        public bool TransferVouchersToUser(VoucherTransferRequest request,String fromUserRoleName, String toUserRole) {
            List<UserVoucher> allVouchers = new List<UserVoucher>();

            foreach (var v in request.TransferRequestItems) {
                List<UserVoucher> userVouchers = _userVoucherRepository.
                    GetFreeUserVouchers(fromUserRoleName, v.Denomination,v.Quantity).ToList();
                if (userVouchers.Count() < v.Quantity) {
                    _logger.LogWarning($"user {fromUserRoleName} has no stocked vouchers of {v.Denomination}birr-{v.Quantity}. Checking system stock. ");

                    int availableStock = userVouchers.Count();
                    int remainingStock = v.Quantity - availableStock;

                    //get the remaining stock 
                    List <UserVoucher> systemStockes = _userVoucherRepository.GetFreeSystemVouchers(v.Denomination, remainingStock).ToList();
                    if (systemStockes.Count() < remainingStock) {
                        _logger.AddUserError($"no enought {v.Denomination} birr stokes are available.");
                        return false;
                    }

                    allVouchers.AddRange(systemStockes);
                }
                allVouchers.AddRange(userVouchers);

            }

            //Transfer the vouchers to the user
            foreach (var v in allVouchers) {
                v.IsCurrent = false;

                var userVoucher = new UserVoucher(toUserRole, v.VoucherId) {
                    IsCurrent = true
                };

                _userVoucherRepository.Create(userVoucher);

            }    


            return true;

        }

        //public void UpdateVoutcher()
        //{
        //    //throw new NotImplementedException();
        //}
    }
}
