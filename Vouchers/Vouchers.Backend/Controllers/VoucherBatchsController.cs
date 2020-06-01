using EthioArt.Backend.Models.Requests;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vouchers.Backend.Controllers
{
    public class VoucherBatchsController: VoucherControllersBase
    {
        public VoucherBatchsController(IUserMessageLogges logs) :
            base(logs)
        {
            
        }

        [HttpGet]
        public IActionResult ListBatches([FromQuery] PagedItemRequestBase request) {
            return Ok();
        }
        

        [HttpPost]
        public IActionResult ActivateBatch([FromBody]String id) {
            return Ok();
        }


    }
}
