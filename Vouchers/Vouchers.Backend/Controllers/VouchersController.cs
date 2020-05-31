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

namespace Vouchers.Backend.Controllers
{
    public class VouchersController : FileUploadControllerBase
    {
        private readonly IVoucherUploadService _voucherUploadService;

        public VouchersController(IUserMessageLogges logs,
            IVoucherUploadService voucherUploadService,
            IWebHostEnvironment hostingEnvironment) :
            base(logs,hostingEnvironment)
        {
            _voucherUploadService = voucherUploadService;

        }

        [HttpGet]
        public IActionResult GetVouchers() {
            return Ok();
        }

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
