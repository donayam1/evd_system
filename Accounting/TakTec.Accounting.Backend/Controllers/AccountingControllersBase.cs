using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TakTec.Accounting.Backend.Controllers
{
    [Route("api/accounting/[controller]")]
    public class AccountingControllersBase:ControllersBase 
    {
        public AccountingControllersBase(IUserMessageLogges logs) :
            base(logs)
        { }
    }
    
    
}
