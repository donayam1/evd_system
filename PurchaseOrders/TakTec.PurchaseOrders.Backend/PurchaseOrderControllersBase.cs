using System;
using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;

namespace TakTec.PurchaseOrders.Backend
{
    [Route("/api/purchaseOrders/[controller]")]
    public class PurchaseOrderControllersBase: ControllersBase
    {
        public PurchaseOrderControllersBase(IUserMessageLogges logs) :
            base(logs)
        { }
    }
}
