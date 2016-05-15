using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LeadisTeam.LeadisJourney.Api.Ioc;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Api.Security;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LeadisTeam.LeadisJourney.Api
{
    public class Startup
    {

        private readonly IHostingEnvironment _env;
        public Startup(IHostingEnvironment env)
        {
            _env = env;
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            #region Token Bearer
            services.AddJwtAuthentication(Path.Combine(_env.WebRootPath, "../Security"), "RsaKey.json", "noobs", "http://leadisjourney.fr");
            #endregion

            // Add framework services.
            services.AddMvc();
            services.AddCors(option => option.AddPolicy("AllowAll", p => p.AllowAnyOrigin()));

#if DNX451
			// Adding ioc Autofac
			var containerBuilder = new ContainerBuilder();
			containerBuilder.Populate(services);

			containerBuilder.RegisterModule<GlobalRegistration>();
			var container = containerBuilder.Build();
			return container.Resolve<IServiceProvider>();
#else
	        return services.BuildServiceProvider();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

			// disable because we do not target IIS engine
            //app.UseIISPlatformHandler();
            app.UseExceptionHandler(appBuilder => {
                appBuilder.Use(async (context, next) => {
                    var error = context.Features[typeof (IExceptionHandlerFeature)] as IExceptionHandlerFeature;
                    if (error != null && error.Error != null) {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject(
                                new HandleErrorsModel {
                                    Title = "An error occured !",
                                    Code = 500,
                                    Message = error.Error.Message
                                }));
                    }
                    else
                        await next();
                });
            });

            app.UseStaticFiles();
            app.UseJwtAuthentication(Path.Combine(_env.WebRootPath, "../Security"), "RsaKey.json", "noobs", "http://leadisjourney.fr");
            app.UseCors("AllowAll");
            app.UseMvc();



        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
