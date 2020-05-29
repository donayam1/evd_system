using Messages.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic
{
    public class VoucherUploadService : IVoucherUploadService
    {
        private readonly IHubContext<VoucherSignalHub> _hubContext;
        public VoucherUploadService(IHubContext<VoucherSignalHub> hubContext) {
            this._hubContext = hubContext;
        }
        public void UploadVoutchersAsync(UploadedFile file)
        {
            
            var t = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                UploadVoucherResponse response = new UploadVoucherResponse() {
                    Status = true,
                    Messages = new List<Message>() {
                         new Message("Success",Messages.Enumeration.MessageTypes.USER_MESSAGE,"200")
                     }
                };
                this._hubContext.Clients.All.SendAsync("VoutureUploadStatus", response);

                System.Threading.Thread.Sleep(5000);
                UploadVoucherResponse response2 = new UploadVoucherResponse()
                {
                    Status = false,
                    Messages = new List<Message>()
                    {
                        new Message("Error",Messages.Enumeration.MessageTypes.USER_ERROR_REPORT,"200")
                    }
                };
                this._hubContext.Clients.All.SendAsync("VoutureUploadStatus", response2);

            }).ConfigureAwait(false);
            
            return;
        }
    }
}
