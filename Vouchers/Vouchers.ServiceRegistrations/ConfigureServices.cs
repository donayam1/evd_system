using ExtCore.Infrastructure.Actions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Vouchers.BusinessLogic;
using Vouchers.BusinessLogic.Abstractions;
using Vouchers.Configurations;

namespace Vouchers.ServiceRegistrations
{
    public class ConfigureServices : IConfigureServicesAction
    {
        public int Priority => 2000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {            
            services.AddSignalR();
            services.AddScoped<IVoucherUploadService, VoucherUploadService>();
            services.AddTransient<IVoucherFileProcessor, VoucherFileProcessor>();

            services.AddSingleton< IVoucherFileProcessorTaskes, VoucherFileProcessorTaskes > ();
            services.AddHostedService<MyBackGroudService>();

            IConfiguration config = serviceProvider.GetService<IConfiguration>()
                ??throw new NullReferenceException(nameof(IConfiguration));

            var configSection = config.GetSection("VoucherFileTags") ??
                throw new Exception($"Configruation section with name VoucherFileTags not found");
            services.Configure<VoucherFileParameters>(configSection);
            
        }
    }
}
