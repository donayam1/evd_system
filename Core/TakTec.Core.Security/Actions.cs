using EthioArt.Configurations;
using ExtCore.Infrastructure.Actions;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using TaKTec.Core.APIs;

namespace TakTec.Core.Security
{
    public class Actions : IConfigureServicesAction
    {
        public int Priority => 2000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            //IConfiguration config = serviceProvider.GetService<IConfiguration>();
            //TODO check for null
            EndPoints endPoints = serviceProvider.GetService<IOptions<EndPoints>>().Value ??
                throw new ArgumentNullException(nameof(endPoints));
            var epLogger = serviceProvider.GetService<ILogger<Actions>>() ??
                throw new ArgumentNullException(nameof(ILogger<Actions>));
            IWebHostEnvironment env = serviceProvider.GetService<IWebHostEnvironment>() ??
                throw new ArgumentNullException(nameof(IWebHostEnvironment));

            epLogger.LogInformation($"auth endpoint is {endPoints.AuthServer} with enviroment{env.EnvironmentName}");

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme).
           AddIdentityServerAuthentication(EVDAuthenticationNames.EVDAuthenticationName, options =>
           {
               options.Authority = endPoints.AuthServer;
               options.RequireHttpsMetadata = (env.EnvironmentName == Environments.Production);// IsProduction();// String.Compare(env.EnvironmentName, "Production", true) == 0;
               options.ApiName = TakApiNames.EVDApi;
               options.ApiSecret = "secret";
               //options.EnableCaching = true;
           });
        }
    }
}
