using ExtCore.Infrastructure.Actions;
using Microsoft.Extensions.DependencyInjection;
using System;
using TakTec.Accounting.BusinessLogic;
using TakTec.Accounting.BusinessLogic.Abstractions;

namespace TakTec.Accounting.ServiceRegistration
{
    public class ConfigureServices : IConfigureServicesAction
    {
        public int Priority => 2000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            services.AddScoped<IBankAccountService, BankAccountsService>();
            services.AddScoped<IBankService, BanksService>();
            
        }
    }
}
