
using System;
using ExtCore.Infrastructure.Actions;
using Microsoft.Extensions.DependencyInjection;
using TakTec.Operators.BusinessLogic;
using TakTec.Operators.BusinessLogic.Abstraction;

namespace TakTec.Operators.ServiceRegistrations
{

    public class ConfigureServices : IConfigureServicesAction
    {
        public int Priority => 2000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            services.AddScoped<IOperatorService, OperatorService>();
        }
    }
}
