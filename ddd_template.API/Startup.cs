using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ddd_template.Application.Servicecs;
using ddd_template.Domain.Accounts.Repositories;
using ddd_template.Domain.Accounts.Services;
using ddd_template.Domain.Customers.Repositories;
using ddd_template.Domain.Customers.Services;
using ddd_template.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ddd_template.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }




        //dotnet core has three environments:
        //development, appsetting.development.json (local debug mode)
        //staging, appsetting.staging.json (uat)
        //production, appsetting.production.json (live)
        //this three environments also apply to autofac DI setup

        //default DI if no environments is setup
        public void ConfigureContainer(ContainerBuilder builder)
        {

        }

        //development DI
        public void ConfigureDevelopmentContainer(ContainerBuilder builder)
        {
            //microsoft DI provides three different lifetime scopes
            //singleton: once the web api is started, it will only have one object globally
            //scope: unique instance is created per api request, same instance is return if under same api request
            //transient: unique instance is created each time is required

            //autofac has many more scopes, concept is the same

            //application
            builder.RegisterType<CustomerApplicationService>().As<ICustomerApplicationService>().InstancePerLifetimeScope();
            builder.RegisterType<AccountApplicationService>().As<IAccountApplicationService>().InstancePerLifetimeScope();

            //domain
            builder.RegisterType<CustomerDomainService>().As<ICustomerDomainService>().InstancePerLifetimeScope();
            builder.RegisterType<AccountDomainService>().As<IAccountDomainService>().InstancePerLifetimeScope();

            //infrastructure
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>().SingleInstance();
        }

        //staging DI
        public void ConfigureStagingContainer(ContainerBuilder builder)
        {

        }

        //production DI
        public void ConfigureProductionContainer(ContainerBuilder builder)
        {

        }
    }
}
