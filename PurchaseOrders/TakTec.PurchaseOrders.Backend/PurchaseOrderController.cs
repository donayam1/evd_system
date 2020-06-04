using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Core.Security;
using TakTec.PurchaseOrders.BusinessLogic.Abstractions;
using TakTec.PurchaseOrders.ViewModels;

namespace TakTec.PurchaseOrders.Backend
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
                    response.NewPurchaseOrder = (NewPurchaseOrderResult)res;
                }

                SendResult(response);

            }
            return BadRequest(ModelState);
        }
        
    }
}
