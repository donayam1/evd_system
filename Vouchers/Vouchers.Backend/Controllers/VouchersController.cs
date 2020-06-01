using Messages.BusinessLogic.Abstraction;
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
        public IActionResult Get([FromQuery] PagedItemRequestBase request) {
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
                   Policy = TakTec.Core.Security.Policies.UploadVoucherPolicy)]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {

            UploadedFile file = this.UploadTheFile();
            if (file.Status == true)
            {
                _voucherUploadService.UploadVoutchersAsync(file);
                return Ok(true);
            }
            else
            {

            }
            return Ok(true);
            
        }

    }
}
