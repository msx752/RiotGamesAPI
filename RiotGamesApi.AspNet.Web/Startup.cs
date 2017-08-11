using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using RiotGamesApi.Enums;

[assembly: OwinStartupAttribute(typeof(RiotGamesApi.AspNet.Web.Startup))]

namespace RiotGamesApi.AspNet.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var services = new ServiceCollection();
            ConfigureAuth(app);
            ConfigureRiotGamesApi(app, services);
        }

        public void ConfigureRiotGamesApi(IAppBuilder app, IServiceCollection services)
        {
            services.AddLeagueOfLegendsApi("RGAPI-18a0744d-3108-4f77-bc47-845d7833b77e",
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

            app.UseRiotGamesApi(services);
        }
    }
}