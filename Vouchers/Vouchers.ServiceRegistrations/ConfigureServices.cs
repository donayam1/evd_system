using ExtCore.Infrastructure.Actions;
using Microsoft.Extensions.DependencyInjection;
using System;
using Vouchers.BusinessLogic;
using Vouchers.BusinessLogic.Abstractions;

namespace Vouchers.ServiceRegistrations
{
    public class ConfigureServices : IConfigureServicesAction
    {
        public int Priority => 2000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {            
            services.AddSignalR();
            services.AddScoped<IVoucherUploadService, VoucherUploadService>();
        }
    }
}
