using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Vouchers.BusinessLogic;

namespace Vouchers.Backend.Actions
{
    public class UseEndpointsActions :ExtCore.Mvc.Infrastructure.Actions.IUseEndpointsAction
    {
        public int Priority => 2000;

        
        public void Execute(IEndpointRouteBuilder rb, IServiceProvider serviceProvider)
        {
            rb.MapControllerRoute(
                name: "VoucherRouting",
                pattern: "api/vouchers/{controller}/{action=Index}/{id?}");
            rb.MapHub<VoucherSignalHub>("/singalHub");
        }
    }
}
