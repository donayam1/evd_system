using AspNetIdentity.Data.Entities;
using EthioArt.Backend.Models.Requests;
using EthioArt.Syncronization.Abstractions;
using EthioArt.UserAccounts.Services.Abstractions;
using ExtCore.Data.Abstractions;
using Messages.Logging.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TakTec.PurchaseOrders.BusinessLogic.Abstractions;
using TakTec.PurchaseOrders.Data.Abstractions;
using TakTec.PurchaseOrders.ObjectMappers;
using TakTec.PurchaseOrders.ViewModels;
using TakTec.Users.Constants;
using Users.BusinessLogic.Abstraction;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.Data.Entities;
using Vouchers.ObjectMapper;
using Vouchers.Shared.ViewModels;
using Vouchers.ViewModels;
//using Vouchers.Data.Entities;
//using Vouchers.ViewModels;

namespace TakTec.PurchaseOrders.BusinessLogic
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly ILogger<IPurchaseOrderService> _logger;
        private readonly ITokenUserService _tokenUserService;
        private readonly IStorage _storage;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IVoucherService _voucherService;
        private readonly IGlobalSyncronizationStore _globalSyncronizationStore;
        private readonly UserManager<AspNetUser> _userManager;
        private readonly IAccountService _accountService;

        public PurchaseOrderService(ILogger<IPurchaseOrderService> logger,
            ITokenUserService tokenUserService,
            IStorage storage,
            IVoucherService voucherService,
            IGlobalSyncronizationStore globalSyncronizationStore,
            UserManager<AspNetUser> userManager,
            IAccountService accountService)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tokenUserService = tokenUserService ??
                throw new ArgumentNullException(nameof(tokenUserService));
            _storage = storage ?? throw new ArgumentNullException(nameof(IStorage));
            _purchaseOrderRepository = _storage.GetRepository<IPurchaseOrderRepository>() ??
                throw new ArgumentNullException(nameof(IPurchaseOrderRepository));
            _voucherService = voucherService ??
                throw new ArgumentNullException(nameof(IVoucherService));
            _globalSyncronizationStore = globalSyncronizationStore ??
                throw new ArgumentNullException(nameof(globalSyncronizationStore));
            _userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));
            _accountService = accountService ??
                throw new ArgumentNullException(nameof(accountService));

        }
        /// <summary>
        /// When a purchase order is set, just create it. when it is confirmed then sell it.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool validate(InternalPurchaseOrderRequest request)
        {
            //assert items are available    
            AspNetUser? buyerUser = null;
            if (request.Self)
            {
                buyerUser = _accountService.GetUser(_tokenUserService.UserId);
            }
            else
            {
                buyerUser = _accountService.GetUser(request.UserId);
                //assert that the buyer user is under the current user
                if (buyerUser.OwnerId != _tokenUserService.UserRole)
                {
                    _logger.AddUnauthorizedError();
                    return false;
                }
            }

            if (request.Items.Count() <= 0) {
                _logger.AddUserError("No items specified.");
                return false;
            }

            if (request.IsExternalOrder) {
                if (_tokenUserService.UserRole != RoleTypeConstants.RoleNameSupperAdmin) {
                    _logger.AddUnauthorizedError();
                    _logger.LogError($"Role {_tokenUserService.UserRole} trying to make an external Po request");
                    return false;
                 }
                return true;
            }

            var transerRequest = new VoucherTransferRequest()
            {
                TransferRequestItems = request.Items.Cast<VoucherTransferRequestItem>().ToList(),
                BatchId = request.BatchId,
                IsApproved = request.IsApproved
            };
            String buyserUserRoleName = buyerUser.AspNetUserRoles.FirstOrDefault().AspNetRole.Name;
            String buyerUserOwnerRoleName = buyerUser.AspNetUserRoles.FirstOrDefault().AspNetRole.OwnerId;
            if (!_voucherService.AreVouchersAvailable(
                    transerRequest,
                    buyerUserOwnerRoleName, buyserUserRoleName))
            {
                _logger.AddUserError("Requested vouchers are not available");
                return false;
            }

            //calculate total ammount 
            float total = 0;
            foreach (var item in request.Items)
            {
                total += (item.Denomination * item.Quantity);
            }

            //TODO assert the user has balance 


            return true;
        }
        public CreatePurchaseOrdreResult? CreatePurchaseOrder(NewPurchaseOrderModel request) {
            InternalPurchaseOrderRequest request1 = new InternalPurchaseOrderRequest()
            {
                BatchId = null,
                IsExternalOrder = request.IsExternalOrder,
                IsApproved = true,
                Id = request.Id,
                Items = request.Items,
                PurchaseOrderNumber = request.PurchaseOrderNumber,
                Self = request.Self,
                UserId = request.UserId
            };

            return this.CreatePurchaseOrder(request1);            
        }

        private CreatePurchaseOrdreResult? CreatePurchaseOrder(InternalPurchaseOrderRequest request)
        {
            List<ILocable> locables = request.Items.ConvertAll<ILocable>(x => x);

            return (CreatePurchaseOrdreResult?)_globalSyncronizationStore.LockAndExecute((x) =>
            {
                CreatePurchaseOrdreResult? res = this.createPurchaseOrder(request);
                return res;
            }
            , request, locables);
        }

        private CreatePurchaseOrdreResult? createPurchaseOrder(InternalPurchaseOrderRequest request)
        {

            if (!validate(request))
            {
                _logger.AddUserError("Invalid request");
                return null;
            }

            //TODO create and do the business transaction  

            //finally create the po
            //transer the voucher to the user
            //then the user can sync to get his voucher cards

            AspNetUser? buyerUser;
            if (request.Self)
            {
                buyerUser = _accountService.GetUser(_tokenUserService.UserId);// _userManager.FindByIdAsync(_tokenUserService.UserId).Result;
            }
            else
            {
                buyerUser = _accountService.GetUser(request.UserId);// _userManager.FindByIdAsync(request.UserId).Result;
            }

            if (buyerUser == null)
            {
                throw new Exception("Unknowen user");
            }

            String buyerUserRole = buyerUser.AspNetUserRoles.FirstOrDefault().AspNetRole.Name;
            String buyerUserOwnerRoleName = buyerUser.AspNetUserRoles.FirstOrDefault().AspNetRole.OwnerId;

            CreatePurchaseOrdreResult result = new CreatePurchaseOrdreResult();

            String userId = _tokenUserService.UserId;
            var po = request.ToDomainModel(userId, buyerUserRole);

            //TODO this is the line causing confilct fix it.
            _purchaseOrderRepository.Create(po);

            result.PurchaseOrder = po.ToNewPoViewModel();
            //NewPurchaseOrderResult result = new NewPurchaseOrderResult();
            //result.UI_Id = request.Id;

            if (request.IsExternalOrder)
            {
                
            }
            else {

                //transer the voucher to the user
                var voucherTransferReqeust = new VoucherTransferRequest()
                {
                    PurchaseOrderId = po.Id,
                    BatchId = request.BatchId,
                    IsApproved = request.IsApproved,

                    TransferRequestItems = request.Items.Cast<VoucherTransferRequestItem>().ToList()
                };

                List<Voucher?>? vouchers = _voucherService.TransferVouchersToUser(
                     voucherTransferReqeust,
                     buyerUserOwnerRoleName, buyerUserRole
                 );

                    if (vouchers == null) {
                        _logger.LogError("Error transfering vouchers to user.");
                        return null;
                    }

                result.Vouchers = vouchers;//.Select(x=>x.Voucher).ToList();

            }

            //then the user can sync to get his voucher cards
            try
            {
                _storage.Save();
                //return result;
            }
            catch (Exception e)
            {
                _logger.AddUserError("Unknowen error, Please contact the administrator.");
                _logger.LogError(e.InnerException, e.Message);
                return null;
            }
            return result;
        }

        public List<PurchaseOrderModel> ListPuchaseOrders(ListPurchaseOrderRequest request) {
            var userRole =_tokenUserService.UserRole;
            return _purchaseOrderRepository.WithOwnerItemId(userRole)
                .Where(x=>x.IsExternalOrder == request.IsExternalOrder)
                .OrderBy(x=>x.DatabaseAddedDateTime)
                .Skip(request.Page-1).Take(request.ItemsPerPage)
                .ToList().ToViewModel();
        }

        

        public PeekVoucherResult? PeekVoucher(PeekVoucherRequest request) {
            var batch = _voucherService.GetBatch(request.BatchId);
            if (batch == null) {
                return null;
            }


            PurchaseOrderItemModel item = new PurchaseOrderItemModel() { 
                Quantity = 1,
                 Denomination = batch.Denomination
            };

            InternalPurchaseOrderRequest poReq = new InternalPurchaseOrderRequest()
            {
                IsExternalOrder = false,
                Self = true,
                IsApproved = false,
                PurchaseOrderNumber = Guid.NewGuid().ToString(),
                BatchId = request.BatchId,
                Items  = new List<PurchaseOrderItemModel>() { 
                    item
                },
                Id = Guid.NewGuid().ToString()                  
            };

            var res = this.CreatePurchaseOrder(poReq);
            if (res == null) {
                return null;
            }

            PeekVoucherResult result = new PeekVoucherResult() { 
                PurchaseOrder = res.PurchaseOrder,
                Vouchers = res.Vouchers.ToViewModel()
            };

            return result;//.UserVouchers?.FirstOrDefault()?.Voucher?.ToSalesViewModel();
        }



    }
}
