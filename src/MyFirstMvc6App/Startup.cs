using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DIDemo.ExampleClasses;
using DIDemo.Services;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Mvc;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace DIDemo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<IDemoService, DemoService>();
            services.AddTransient<ITransientDependencyExample, TransientDependencyExample>();
            services.AddScoped<IScopedDependencyExample, ScopedDependencyExample>();
            services.AddSingleton<ISingletonDependencyExample, SingletonDependencyExample>();
            services.AddInstance<IInstanceDependencyExample>(new InstanceDependencyExample());
        }

        /**
         * Uncomment this method to use Autofac instead of the default dependency container.
         * /
            /*
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<DemoService>().As<IDemoService>().InstancePerDependency();
            containerBuilder.RegisterType<TransientDependencyExample>().As<ITransientDependencyExample>().InstancePerDependency();
            containerBuilder.RegisterType<ScopedDependencyExample>().As<IScopedDependencyExample>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SingletonDependencyExample>().As<ISingletonDependencyExample>().SingleInstance();
            containerBuilder.RegisterInstance(new InstanceDependencyExample()).As<IInstanceDependencyExample>();

            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return container.Resolve<IServiceProvider>();
        }
        */

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIISPlatformHandler();

            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
