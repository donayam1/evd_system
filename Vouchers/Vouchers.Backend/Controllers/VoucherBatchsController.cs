using EthioArt.Backend.Models.Requests;
using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TakTec.Core.Security;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.ViewModels;

namespace Vouchers.Backend.Controllers
{
    [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName)]
    public class VoucherBatchsController: VoucherControllersBase
    {
        private readonly IVoucherBatchService _voucherBatchService;
        public VoucherBatchsController(IUserMessageLogges logs,
            IVoucherBatchService voucherBatchService) :
            base(logs)
        {
            _voucherBatchService = voucherBatchService ??
                throw new ArgumentNullException(nameof(_voucherBatchService));
                
        }

        [HttpGet]
        public IActionResult ListBatches([FromQuery] ListVoucherBatchesRequest request) {
            return Ok();
        }
        

        [HttpPost]
        public IActionResult ActivateBatch([FromBody]String id) {
            return Ok();
        }


    }
}
