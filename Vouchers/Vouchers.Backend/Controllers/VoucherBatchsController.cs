using EthioArt.Backend.Models.Requests;
using EthioArt.Backend.Models.Responses;
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
        [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName,
            Policy = Policies.ListVoucherBatchPolicy)]
        public IActionResult ListBatches([FromQuery] ListVoucherBatchesRequest request) {
            if (ModelState.IsValid) {
                ListVoucherBatchResponse response = new ListVoucherBatchResponse();
                var batches = _voucherBatchService.ListBatches(request);
                response.Status = true;
                response.VoucherBatches = batches;
                return SendResult(response);
            }
            return BadRequest(ModelState);
        }
        

        [HttpPost]
        [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName,
            Policy = Policies.ActivateVoucherBatchPolicy)]
        public IActionResult ActivateBatch([FromBody]ActivateVoucherBatchRequest request) {

            if (ModelState.IsValid)
            {

                bool res = _voucherBatchService.ActivateBatch(request.Id);
                ResponseBase response = new ResponseBase() {
                    Status = res
                };

                return SendResult(response);

            }
            return BadRequest(ModelState);
        }


    }
}
