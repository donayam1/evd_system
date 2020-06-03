using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Core.Security;

namespace TakTec.PurchaseOrders.Backend
{
    [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName)]
    public class PurchaseOrderController: PurchaseOrderControllersBase
    {
        public PurchaseOrderController(IUserMessageLogges logs) :
            base(logs)
        { 
        }

        
    }
}
