using ExtCore.Data.EntityFramework;
using ExtCore.WebApplication.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostApp
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private string extensionsPath;

        public Startup(IHostEnvironment hostingEnvironment, IConfiguration configuration, ILogger<Startup> logger)//
        {
            this.Configuration = configuration;//builder.Build();//
            this.extensionsPath = hostingEnvironment.ContentRootPath + this.Configuration["Extensions:Path"];
            logger.LogInformation("Enviroment name is =" + hostingEnvironment.EnvironmentName);
        }



        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<StorageContextOptions>(options => {
                options.ConnectionString = this.Configuration.GetConnectionString("Default");
            });

            services.AddExtCore(this.extensionsPath, this.Configuration["Extensions:IncludingSubpaths"] == true.ToString());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //This allows identity server to recive the request over https
            //https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-2.2
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseExtCore();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

        }
    }
}
