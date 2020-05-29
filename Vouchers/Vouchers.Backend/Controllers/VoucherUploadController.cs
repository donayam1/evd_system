using Messages.BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vouchers.BusinessLogic.Abstractions;

namespace Vouchers.Backend.Controllers
{
    public class VoucherUploadController : VoucherControllersBase
    {
        private readonly IVoucherUploadService _voucherUploadService;
        public VoucherUploadController(IUserMessageLogges logs,
            IVoucherUploadService voucherUploadService) :
            base(logs)
        {
            _voucherUploadService = voucherUploadService;
            
        }


        [HttpPost]
        public async Task<IActionResult> UploadVouchers() {
            await _voucherUploadService.UploadVoutchers();
            return Ok(true);
        }


    }
}
