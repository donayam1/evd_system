using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Vouchers.BusinessLogic;

namespace Vouchers.ServiceRegistrations
{
    public class ConfigureActions : ExtCore.Infrastructure.Actions.IConfigureAction
    {
        public int Priority => 2000;

        public void Execute(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseSignalR(routes => {
                routes.MapHub<VoucherSignalHub>("/singalHub");
            });
        }
    }
}
