using System;
using ExtCore.Infrastructure.Actions;
using Microsoft.Extensions.DependencyInjection;
using TakTec.RetailerPlans.BusinessLogic;
using TakTec.RetailerPlans.BusinessLogic.Abstraction;
namespace TakTec.RetailerPlans.ServiceRegistrations
{
    public class ConfigureServices :IConfigureServicesAction
    {
        public int Priority => 2000;
        public void Execute(IServiceCollection services,IServiceProvider serviceProvider)
        {
            services.AddScoped<IRetailerPlanService,RetailerPlanService>();
        }
    }
}
