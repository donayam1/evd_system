using ExtCore.Infrastructure.Actions;
using Microsoft.Extensions.DependencyInjection;
using Roles.BusinessLogic.Abstraction;
using System;
using TakTec.Users.BusinessLogic;

namespace TakTec.Users.ServiceRegistrations
{
    public class ConfigureServices : IConfigureServicesAction
    {
        public int Priority => 2000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            services.AddScoped< IManageRoleTypeValidator, ManageRoleTypeValidator   > ();
        }
    }
}
