using System;
using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace TakTec.PurchaseOrders.Backend.Controllers
{
    [Route("/api/purchaseOrders/[controller]")]
    public class PurchaseOrderControllersBase: ControllersBase
    {
        public PurchaseOrderControllersBase(IUserMessageLogges logs) :
            base(logs)
        { 
        }

    }
}
