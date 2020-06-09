using EthioArt.Backend.Models;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Components;
using System;

namespace TakTec.Accounting.Backend
{
    [Route("api/accounting/[controller]")]
    public class AccountingControllersBase:ControllersBase 
    {
        public AccountingControllersBase(IUserMessageLogges logs) :
            base(logs)
        { }
    }
    
    
}
