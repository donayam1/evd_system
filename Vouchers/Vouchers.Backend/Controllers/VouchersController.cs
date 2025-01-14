﻿using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vouchers.BusinessLogic.Abstractions;
using System.IO;
using System.Net.Http.Headers;
using Vouchers.ViewModels;
using EthioArt.Backend.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using TakTec.Core.Security;
using EthioArt.Security.Constants;
using EthioArt.Backend.Models.Responses;
using Microsoft.AspNetCore.Http;

namespace Vouchers.Backend.Controllers
{
    [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName)]
    public class VouchersController : FileUploadControllerBase
    {
        private readonly IVoucherUploadService _voucherUploadService;
        private readonly IVoucherService _voucherService;
        public VouchersController(IUserMessageLogges logs,
            IVoucherUploadService voucherUploadService,
            IWebHostEnvironment hostingEnvironment,
            IVoucherService voucherService) :
            base(logs,hostingEnvironment)
        {
            _voucherUploadService = voucherUploadService ??
                throw new ArgumentNullException(nameof(IVoucherUploadService));
            _voucherService = voucherService ??
                throw new ArgumentNullException(nameof(IVoucherService));
        }

        [HttpGet(template: "Statistics")]
        public IActionResult GetVoucherStatistics()
        {
            if (ModelState.IsValid) {
                var res = _voucherService.GetVoucherStatistics();
                VoucherStatisticsResponse response = new VoucherStatisticsResponse();
                response.Status = true;
                response.VoucherStatistics = res;
                return SendResult(response);
            }
            return BadRequest(ModelState);
        }

        [HttpGet(template: "denominations")]
        public IActionResult GetAvailableDenominations()
        {
            if (ModelState.IsValid)
            {
                VoucherStatisticsResponse response = new VoucherStatisticsResponse() {
                    Status = true
                };
                var res = _voucherService.GetFreeSystemAvailabelDenominations();
                response.VoucherStatistics = res;
                return SendResult(response);
            }
            return BadRequest(ModelState);
        }


        [HttpGet]      
        public IActionResult Get([FromQuery] ListVoucherRequest request) {
            if (ModelState.IsValid) {

                var res = _voucherService.ListVoutchers(request);
                ListVouchersResponse response = new ListVouchersResponse()
                {
                    Status = true,
                    Vouchers = res

                };
                return SendResult(response);
            }
            return BadRequest(ModelState);
        }

        [HttpPost(template:"CheckOut")]
        public IActionResult CheckOutVouchers([FromBody] ListVoucherRequest request) {
            if (ModelState.IsValid) {
                ListVouchersResponse response = new ListVouchersResponse();
                var res = _voucherService.CheckOutVoutchers(request);
                if (res == null)
                {
                    response.Status = false;
                }
                else {
                    response.Status = true;
                    response.Vouchers = res;
                }
                return SendResult(response);
            }
            return BadRequest(ModelState);
        }


        [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName,
                   Policy = TakTec.Core.Security.Policies.UploadVoucherBatchPolicy)]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload(IFormCollection data0)
        {
            if (ModelState.IsValid)
            {
                ResponseBase response = new ResponseBase()
                {
                    Status = false
                };
                UploadVoucherBatchData data = new UploadVoucherBatchData();
                var poId = data0["purchaseOrderId"];
                UploadedFile file = this.UploadTheFile();
                if (file.Status == true)
                {
                    file.PurchaseOrderId = poId.ToString();
                    _voucherUploadService.ScheduleUploadedVoucherFileProcessor(file);
                    response.Status = true;
                }
                else
                {
                    response.Status = false;
                }
                return SendResult(response);
            }
            return BadRequest(ModelState);

        }


        

    }
}
