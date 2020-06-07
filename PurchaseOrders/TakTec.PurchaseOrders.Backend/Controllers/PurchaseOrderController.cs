using EthioArt.Backend.Models.Requests;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Core.Security;
using TakTec.PurchaseOrders.BusinessLogic.Abstractions;
using TakTec.PurchaseOrders.ViewModels;
using System.Linq;

namespace TakTec.PurchaseOrders.Backend.Controllers
{
    [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName)]
    public class PurchaseOrderController: PurchaseOrderControllersBase
    {
        public readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IUserMessageLogges logs,
            IPurchaseOrderService purchaseOrderService) :
            base(logs)
        {
            _purchaseOrderService = purchaseOrderService ??
                throw new ArgumentNullException(nameof(purchaseOrderService));
        }
        [HttpPost(template:"CreatePurchaseOrder")]
        public IActionResult CreatePurcaseOrder([FromBody]NewPurchaseOrderModel request) {
            if (ModelState.IsValid) {
                NewPurchaseOrderResponse response =
                    new NewPurchaseOrderResponse();
                var res = _purchaseOrderService.CreatePurchaseOrder(request);
                if (res == null) {
                    response.Status = false;
                }
                else{
                    response.Status = true;
                    response.NewPurchaseOrder = (NewPurchaseOrderResult)res.PurchaseOrder;
                }

                return SendResult(response);

            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult ListPurcaseOrder([FromQuery]PagedItemRequestBase request)
        {
            if (ModelState.IsValid)
            {
                ListPurchaseOrderResponse response =
                    new ListPurchaseOrderResponse();
                var res = _purchaseOrderService.ListPuchaseOrders(request);
                if (res == null)
                {
                    response.Status = false;
                }
                else
                {
                    response.Status = true;
                    response.PurchaseOrders = res;
                }

                return SendResult(response);

            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName,
                   Policy = TakTec.Core.Security.Policies.PeekAVoucherPolicy)]
        public IActionResult OpenVoucher([FromBody]PeekVoucherRequest request)
        {
            if (ModelState.IsValid)
            {
                var res = _purchaseOrderService.PeekVoucher(request);
                PeekVoucherResponse response = new PeekVoucherResponse();
                if (res != null)
                {
                    response.Status = false;
                }
                else {
                    response.Status = true;
                    response.PurchaseOrder = res.PurchaseOrder;
                    response.Voucher = res.Vouchers.FirstOrDefault();
                }

                return SendResult(response);

            }
            return BadRequest(ModelState);
        }


    }
}
