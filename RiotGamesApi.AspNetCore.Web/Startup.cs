using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.Enums;

/*
    using RiotGamesApi.AspNetCore;

    add this reference for using .net core middleware
 * */

namespace RiotGamesApi.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //necessary
            services.AddLeagueOfLegendsApi("RGAPI-440fcd4b-a43f-4d80-92b5-bd50c0df1893",
            (cache) =>
            {
                //overrides default values
                cache.EnableStaticApiCaching = true;
                cache.StaticApiCacheExpiry = new TimeSpan(1, 0, 0);

                //custom caching is activated
                //working for any api except static-api
                cache.EnableCustomApiCaching = true;
                //summoner-profiles are cached for 5sec
                cache.AddCacheRule(LolUrlType.NonStatic, LolApiName.Summoner, new TimeSpan(0, 0, 5));
                return cache;
            },
            (limits) =>
            {
                limits.DisableLimiting = false;
                limits.AddXAppRateLimits(new Dictionary<TimeSpan, int>()//your api limits
                {
                    {new TimeSpan(0, 2, 0), 100 },
                    {new TimeSpan(0, 0, 1), 20 }
                });

                return limits;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //necessary
            app.UseRiotGamesApi();
        }
    }
}