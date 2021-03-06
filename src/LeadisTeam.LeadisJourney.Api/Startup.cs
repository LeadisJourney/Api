﻿using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LeadisTeam.LeadisJourney.Api.Ioc;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Api.Security;
using LeadisTeam.LeadisJourney.Core.Configuration;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;
using LeadisTeam.LeadisJourney.Services.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog.Extensions.Logging;

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
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            #region Token Bearer
            services.AddJwtAuthentication(Path.Combine(_env.ContentRootPath, "./Security"), "RsaKey.json", "noobs", "http://leadisjourney.fr");
            #endregion

            services.AddNHibernate(Configuration.GetConnectionString("type"), Configuration.GetConnectionString("DefaultConnection"));

            // Add framework services.
            services.AddMvc();
            services.AddCors(option => option.AddPolicy("AllowAll", p =>
            {
                p.AllowAnyOrigin();
                p.AllowCredentials();
                p.AllowAnyMethod();
                p.AllowAnyHeader();
            }));

            services.Configure<ServerConfiguration>(Configuration.GetSection("Server"));

            // Adding ioc Autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterModule<GlobalRegistration>();
            var container = containerBuilder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //add NLog to ASP.NET Core
            loggerFactory.AddNLog();
            //needed for non-NETSTANDARD platforms: configure nlog.config in your project root
            env.ConfigureNLog("nlog.config");

            // disable because we do not target IIS engine
            //app.UseIISPlatformHandler();
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;
                    if (error != null && error.Error != null)
                    {
                        if (error.Error is BusinessException)
                        {
                            context.Response.StatusCode = 400;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(
                                JsonConvert.SerializeObject(
                                    new HandleErrorsModel
                                    {
                                        Title = "An error occured !",
                                        Code = 400,
                                        Message = error.Error.Message
                                    }));

                        }
                        else
                        {
                            context.Response.StatusCode = 500;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(
                                JsonConvert.SerializeObject(
                                    new HandleErrorsModel
                                    {
                                        Title = "An error occured !",
                                        Code = 500,
                                        Message = error.Error.Message
                                    }));
                        }
                    }
                    else
                        await next();
                });
            });

            app.UseStaticFiles();
            app.UseJwtAuthentication(Path.Combine(_env.ContentRootPath, "./Security"), "RsaKey.json", "noobs", "http://leadisjourney.fr");
            app.UseCors("AllowAll");
            app.UseMvc();



        }
    }
}
