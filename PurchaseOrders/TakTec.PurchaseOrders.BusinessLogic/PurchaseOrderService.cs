using AspNetIdentity.Data.Entities;
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
using Users.BusinessLogic.Abstraction;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.Shared.ViewModels;
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
        bool validate(NewPurchaseOrderModel request)
        {
            //assert items are available    
            AspNetUser? buyerUser = null;
            if (request.Self)
            {
                buyerUser = _userManager.FindByIdAsync(_tokenUserService.UserId).Result;
            }
            else
            {
                buyerUser = _userManager.FindByIdAsync(request.UserId).Result;
                //assert that the buyer user is under the current user
                if (buyerUser.OwnerId != _tokenUserService.UserRole)
                {
                    _logger.AddUnauthorizedError();
                    return false;
                }
            }

            if (!_voucherService.AreVouchersAvailable(
                    new VoucherTransferRequest()
                    { TransferRequestItems = request.Items.Cast<VoucherTransferRequestItem>().ToList() },
                    buyerUser.OwnerId))
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

        public PurchaseOrderModel? CreatePurchaseOrder(NewPurchaseOrderModel request)
        {
            List<ILocable> locables = request.Items.ConvertAll<ILocable>(x => x);

            return (PurchaseOrderModel?)_globalSyncronizationStore.LockAndExecute((x) =>
            {
                PurchaseOrderModel? res = this.createPurchaseOrder(request);
                return res;
            }
            , request, locables);
        }

        private PurchaseOrderModel? createPurchaseOrder(NewPurchaseOrderModel request)
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

            String userId = _tokenUserService.UserId;
            var po = request.ToDomainModel(userId);

            //TODO this is the line causing confilct fix it.
            _purchaseOrderRepository.Create(po);

            //NewPurchaseOrderResult result = new NewPurchaseOrderResult();
            //result.UI_Id = request.Id;



            //transer the voucher to the user
            _voucherService.TransferVouchersToUser(
                new VoucherTransferRequest()
                { TransferRequestItems = request.Items.Cast<VoucherTransferRequestItem>().ToList() },
                    buyerUser.OwnerId, buyerUserRole
            );



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

            return po.ToNewPoViewModel();
        }
    }
}
