using Messages.BusinessLogic.Abstraction;
using Messages.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.BusinessLogic.Abstraction;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.ViewModels;

namespace Vouchers.BusinessLogic
{
    public class VoucherUploadService : IVoucherUploadService
    {
        private readonly IHubContext<VoucherSignalHub> _hubContext;
        private readonly IVoucherFileProcessor _voucherFileProcessor;
        private readonly ITokenUserService _tokenUserService;

        public VoucherUploadService(IHubContext<VoucherSignalHub> hubContext,
            IVoucherFileProcessor voucherFileProcessor,
            ITokenUserService tokenUserService) {
            this._hubContext = hubContext ?? 
                throw new ArgumentNullException(nameof(hubContext));
            this._voucherFileProcessor = voucherFileProcessor ??
                throw new ArgumentNullException(nameof(voucherFileProcessor));
            this._tokenUserService = tokenUserService ??
                throw new ArgumentNullException(nameof(_tokenUserService));
        }

        public void UploadVoutchersAsync(UploadedFile file)
        {
            
            var t = Task.Run(() =>
            {
                UploadVoucherResponse response0 = new UploadVoucherResponse()
                {
                    Status = true,
                    Messages = new List<Message>() {
                         new Message("File uploaded, processing .....", Messages.Enumeration.MessageTypes.USER_MESSAGE, "200")
                     }
                };
                this._hubContext.Clients.All.SendAsync("VoutureUploadStatus", response0);

                UploadVoucherResponse response = _voucherFileProcessor.ProcessFile(file.FullPath).Result;                                
                this._hubContext.Clients.All.SendAsync("VoutureUploadStatus", response);


            }).ConfigureAwait(false);
            
            return;
        }
    }
}
