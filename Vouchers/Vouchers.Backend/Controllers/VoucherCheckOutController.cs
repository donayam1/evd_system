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
    public class VoucherCheckOutController: VoucherControllersBase
    {
        private readonly IVoucherService _voucherService;
        public VoucherCheckOutController(IUserMessageLogges logs,
            IVoucherService voucherService) :
            base(logs)
        {
            _voucherService = voucherService ??
                throw new ArgumentNullException(nameof(IVoucherService));
        }

        [HttpPost]
        public IActionResult CheckOutVoucher([FromBody]CheckOutVoucherRequest request) {
            if (ModelState.IsValid) {
                CheckOutVoucherResponse response = new CheckOutVoucherResponse();
                var res = _voucherService.CheckOutVoucher(request);
                if (res == null)
                {
                    response.Status = false;
                }
                else {
                    response.Status = true;
                    response.Voucher = res;
                }
                return SendResult(response);
            }
            return BadRequest(ModelState);
        }

    }
}
