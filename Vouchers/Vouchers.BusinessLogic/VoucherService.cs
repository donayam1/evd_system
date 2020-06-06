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
using Vouchers.Shared.ViewModels;
using TakTec.Users.Constants;

namespace Vouchers.BusinessLogic
{
    public class VoucherService : IVoucherService
    {
        private readonly IStorage _storage;
        private readonly IUserVoucherRepository  _userVoucherRepository;
        private readonly IVouchersRepository _vouchersRepository;

        private readonly ITokenUserService _tokenUserService;
        private readonly ILogger<IVoucherService> _logger;
        private readonly IVoucherBatchRepository _voucherBatchRepository;
        public VoucherService(IStorage storage,
            ITokenUserService tokenUserService,
            ILogger<IVoucherService> logger) {
            _storage = storage ?? 
                throw new ArgumentNullException(nameof(IStorage));
            _userVoucherRepository = _storage.GetRepository<IUserVoucherRepository>() ??
                throw new ArgumentNullException(nameof(IUserVoucherRepository));
            _voucherBatchRepository = _storage.GetRepository<IVoucherBatchRepository>() ??
                throw new ArgumentNullException(nameof(IVoucherBatchRepository));
            _vouchersRepository = _storage.GetRepository<IVouchersRepository>() ??
                throw new ArgumentNullException(nameof(IVouchersRepository));
            _tokenUserService = tokenUserService ??
                throw new ArgumentNullException(nameof(tokenUserService));
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger<IVoucherService>));
        }

        public List<VoucherStatistics> GetVoucherStatistics() {
            String role = _tokenUserService.UserRole;
            List<VoucherStatistics> stats = new List<VoucherStatistics>();
            if (role == RoleTypeConstants.RoleNameSupperAdmin) {
                var res0 = _vouchersRepository.GetFreeSystemVouchers().GroupBy(x => x.Batch.Denomination)
                    .Select(x=>new VoucherStatistics() { Denomination=x.Key,Quantity=x.Count() }).ToList();
                stats.AddRange(res0);
            }

            var res1 = _userVoucherRepository.GetFreeUserVouchers(role).GroupBy(x=>x.Voucher.Batch.Denomination)
                .Select(x => new VoucherStatistics() { Denomination = x.Key, Quantity = x.Count() }).ToList();

            foreach (var v in res1) {
                var dstat = stats.Where(x => x.Denomination == v.Denomination).FirstOrDefault();
                if (dstat != null)
                {
                    dstat.Quantity += v.Quantity;
                }
                else {
                    stats.Add(v);
                }
            }
            return stats;

        }

        public List<VoucherModel> ListVoutchers(ListVoucherRequest request)
        {
            String role = _tokenUserService.UserRole;
            var items = _userVoucherRepository.WithOwnerItemId(role, true, request.IsSyncing,
                request.FromDate?.FromSharedDateTimeString(),
                request.ToDate?.FromSharedDateTimeString()).
                Select(x => x.Voucher);

            if (!String.IsNullOrWhiteSpace(request.BatchId)) {
                items = items.Where(x => x.BatchId == request.BatchId);
            }

            return items.OrderBy(x=>x.DatabaseAddedDateTime).
                ToList().
                ToViewModel();
        }


        public bool AreVouchersAvailable(VoucherTransferRequest request, String fromUserRoleName) {
            foreach (var v in request.TransferRequestItems) {
                int userVouchers = _userVoucherRepository.CountUserFreeVouchers(fromUserRoleName, v.Denomination);
                if (userVouchers < v.Quantity) {
                    int systemFreeVouchers =_vouchersRepository.CountSystemFreeVouchers(v.Denomination, null, isApproved: true);
                    if ((systemFreeVouchers + userVouchers) < v.Quantity)
                    {
                        _logger.AddUserError($"{v.Quantity} vouchers of {v.Denomination} birr not avaiable.");
                        return false;
                    }
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
        public List<Voucher?>? TransferVouchersToUser(VoucherTransferRequest request,
            String fromUserRoleName, String toUserRole) {
            List<Voucher?> allVouchers = new List<Voucher?>();

            foreach (var v in request.TransferRequestItems) {
                List<Voucher?> userVouchers = _userVoucherRepository.
                    GetFreeUserVouchers(fromUserRoleName, v.Denomination,v.Quantity,
                    request.BatchId,request.IsApproved).Select(x=>x.Voucher).ToList();
                if (userVouchers.Count() < v.Quantity) {
                    _logger.LogWarning($"user {fromUserRoleName} has no stocked vouchers of {v.Denomination}birr-{v.Quantity}. Checking system stock. ");

                    int availableStock = userVouchers.Count();
                    int remainingStock = v.Quantity - availableStock;

                    //get the remaining stock 
                    List<Voucher> systemStockes = _vouchersRepository.GetFreeSystemVouchers(v.Denomination,
                        remainingStock, request.BatchId, request.IsApproved).ToList();

                        //_userVoucherRepository.
                        //GetFreeSystemVouchers(v.Denomination, remainingStock, request.BatchId,request.IsApproved).ToList();
                    if (systemStockes.Count() < remainingStock) {
                        _logger.AddUserError($"no enought {v.Denomination} birr stokes are available.");
                        return null;
                    }

                    allVouchers.AddRange(systemStockes);
                }
                allVouchers.AddRange(userVouchers);
            }

            //Transfer the vouchers to the user
            foreach (var v in allVouchers) {
                if (v.IsInSystemPool == true)
                {
                    v.IsInSystemPool = false;                    
                }
                else {
                    var currStatus =v.UserVouchers.Where(x => x.IsCurrent == true).FirstOrDefault();
                    currStatus.IsCurrent = false;
                }

                var userVoucher = new UserVoucher(request.PurchaseOrderId, toUserRole, v.Id)
                {

                };
                _userVoucherRepository.Create(userVoucher);

            }    
            return allVouchers;
        }

        //public void UpdateVoutcher()
        //{
        //    //throw new NotImplementedException();
        //}
        public VoucherBatch? GetBatch(String id) {
            return _voucherBatchRepository.WithKey(id);
        }

    }
}
