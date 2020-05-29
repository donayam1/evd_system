using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vouchers.Backend.Controllers
{
    [Route("api/vouchers/[controller]")]
    public class VoucherControllersBase:ControllersBase
    {
        public VoucherControllersBase(IUserMessageLogges logs) : 
            base(logs) { }
    }
}
