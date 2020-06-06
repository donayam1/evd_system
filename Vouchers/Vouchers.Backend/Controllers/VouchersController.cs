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

        [Authorize(AuthenticationSchemes = EVDAuthenticationNames.EVDAuthenticationName,
                   Policy = TakTec.Core.Security.Policies.UploadVoucherBatchPolicy)]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            ResponseBase response = new ResponseBase()
            {
                Status = false
            };
            UploadedFile file = this.UploadTheFile();
            if (file.Status == true)
            {
                _voucherUploadService.ScheduleUploadedVoucherFileProcessor(file);
                response.Status = true;                
            }
            else
            {
                response.Status = false;
            }
            return SendResult(response);

        }

    }
}
