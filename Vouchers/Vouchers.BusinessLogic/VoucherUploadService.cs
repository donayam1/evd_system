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
        private readonly ITokenUserService _tokenUserService;
        private readonly IVoucherFileProcessorTaskes _voucherFileProcessorTaskes;
        private readonly IVoucherStatusNotificationService _voucherStatusNotificationService;
        public VoucherUploadService(
            ITokenUserService tokenUserService,
            IVoucherFileProcessorTaskes voucherFileProcessorTaskes,
            IVoucherStatusNotificationService voucherStatusNotificationService) {
            this._tokenUserService = tokenUserService ??
                throw new ArgumentNullException(nameof(_tokenUserService));
            _voucherFileProcessorTaskes = voucherFileProcessorTaskes;
            _voucherStatusNotificationService = voucherStatusNotificationService ??
                throw new ArgumentNullException(nameof(IVoucherStatusNotificationService));

        }

        public void ScheduleUploadedVoucherFileProcessor(UploadedFile file)
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
                _voucherStatusNotificationService.NotifyUploadVoucherStatus(response0);
                _voucherFileProcessorTaskes.Enqueue(file);
            });
           
            return;
        }
    }
}
