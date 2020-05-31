using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic
{
    public class VoucherStatusNotificationService: IVoucherStatusNotificationService
    {
        private const String VoucherUpdateStatusJsMethod = "VoutureUploadStatus";

        private readonly IHubContext<VoucherSignalHub> _hubContext;
        
        public VoucherStatusNotificationService(IHubContext<VoucherSignalHub> hubContext)
        {
            _hubContext = hubContext?? 
                throw new ArgumentNullException(nameof(IHubContext<VoucherSignalHub>));
        }

        public async Task NotifyUploadVoucherStatus(UploadVoucherResponse response) {
            await this._hubContext.Clients.All.SendAsync(VoucherUpdateStatusJsMethod, response);

        }

    }
}
