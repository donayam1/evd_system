using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vouchers.BusinessLogic.Abstractions;

namespace Vouchers.BusinessLogic
{
    public class VoucherUploadService : IVoucherUploadService
    {
        private readonly IHubContext<VoucherSignalHub> _hubContext;
        public VoucherUploadService(IHubContext<VoucherSignalHub> hubContext) {
            this._hubContext = hubContext;
        }
        public async Task UploadVoutchers()
        {
            await this._hubContext.Clients.All.SendAsync("RecevieMessage", "don", "good");
        }
    }
}
