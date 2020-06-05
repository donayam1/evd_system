using EthioArt.UserAccounts.Services.Abstractions;
using ExtCore.Infrastructure.Actions;
using Microsoft.Extensions.DependencyInjection;
using Roles.BusinessLogic.Abstraction;
using System;
using TakTec.Users.BusinessLogic;
using TakTec.Users.BusinessLogic.Abstractions;

namespace TakTec.Users.ServiceRegistrations
{
    public class ConfigureServices : IConfigureServicesAction
    {
        public int Priority => 2000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {

            services.AddScoped<IManageRoleTypeValidator, ManageRoleTypeValidator>();
            services.AddScoped<IUserTokenClaimContributingServcie, UserRoleTypeTokenClaimContributingServcie>();
            services.AddScoped<IEVDUserRegistrationService, EVDUserRegistrationService>();
            services.AddScoped<INewUserValidator, NewUserValidator>();

        }
    }
}
