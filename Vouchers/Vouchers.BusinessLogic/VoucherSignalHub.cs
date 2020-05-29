using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Vouchers.BusinessLogic
{
    public class VoucherSignalHub: Hub
    {
        public async Task SendMessage(String user, String message) {
            await Clients.All.SendAsync("RecevieMessage", user, message);
        }

    }
}
