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
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.RateLimit;

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
                limits.AddRateLimitFor(LolUrlType.Static, LolApiName.StaticData,
                    new List<ApiLimit>()
                    {
                        new ApiLimit(new TimeSpan(1, 0, 0),10,RateLimitType.MethodRate)
                    }, LolApiMethodName.Champions,
                    LolApiMethodName.Items,
                    LolApiMethodName.LanguageStrings,
                    LolApiMethodName.LanguageStrings,
                    LolApiMethodName.Maps,
                    LolApiMethodName.Masteries,
                    LolApiMethodName.ProfileIcons,
                    LolApiMethodName.Realms,
                    LolApiMethodName.Runes,
                    LolApiMethodName.SummonerSpells,
                    LolApiMethodName.Versions);

                limits.AddRateLimitFor(LolUrlType.NonStatic, LolApiName.Match,
                    new List<ApiLimit>()
                    {
                        new ApiLimit(new TimeSpan(0, 0, 10),500, RateLimitType.MethodRate)
                    }, LolApiMethodName.Matches, LolApiMethodName.Timelines);

                limits.AddRateLimitFor(LolUrlType.NonStatic, LolApiName.Match,
                    new List<ApiLimit>()
                    {
                        new ApiLimit(new TimeSpan(0, 0, 10),1000, RateLimitType.MethodRate)
                    }, LolApiMethodName.MatchLists);

                limits.AddRateLimitFor(LolUrlType.Status, LolApiName.Status, new List<ApiLimit>()
                {
                    new ApiLimit(new TimeSpan(0, 0, 10), 20000, RateLimitType.MethodRate),
                    new ApiLimit(new TimeSpan(0, 2, 0), 100, RateLimitType.AppRate),
                    new ApiLimit(new TimeSpan(0, 0, 1), 20, RateLimitType.AppRate)
                }, LolApiMethodName.ShardData);

                limits.AddRateLimitFor(LolUrlType.Tournament, new List<LolApiName>()
                    {
                        LolApiName.Tournament,
                        LolApiName.TournamentStub
                    }, new List<ApiLimit>()
                    {
                        new ApiLimit(new TimeSpan(0, 0, 10), 20000, RateLimitType.MethodRate),
                        new ApiLimit(new TimeSpan(0, 2, 0), 100, RateLimitType.AppRate),
                        new ApiLimit(new TimeSpan(0, 0, 1), 20, RateLimitType.AppRate)
                    },
                    LolApiMethodName.Codes,
                    LolApiMethodName.LobbyEvents,
                    LolApiMethodName.Providers,
                    LolApiMethodName.Tournaments);

                limits.AddRateLimitFor(LolUrlType.NonStatic, new List<LolApiName>()
                    {
                        LolApiName.ChampionMastery,
                        LolApiName.League,
                        LolApiName.Spectator,
                        LolApiName.Summoner,
                        LolApiName.Platform,
                    }, new List<ApiLimit>()
                    {
                        new ApiLimit(new TimeSpan(0, 0, 10), 20000, RateLimitType.MethodRate),
                        new ApiLimit(new TimeSpan(0, 2, 0), 100, RateLimitType.AppRate),
                        new ApiLimit(new TimeSpan(0, 0, 1), 20, RateLimitType.AppRate)
                    },
                    LolApiMethodName.ChampionMasteries,
                    LolApiMethodName.Scores,
                    LolApiMethodName.ChallengerLeagues,
                    LolApiMethodName.Leagues,
                    LolApiMethodName.MasterLeagues,
                    LolApiMethodName.Positions,
                    LolApiMethodName.ActiveGames,
                    LolApiMethodName.FeaturedGames,
                    LolApiMethodName.Summoners
                );

                //lol/platform/v3/champions
                //lol/platform/v3/masteries/by-summoner/{summonerId}
                //lol/platform/v3/runes/by-summoner/{summonerId}
                limits.AddRateLimitFor(LolUrlType.NonStatic, new List<LolApiName>()
                    {
                        LolApiName.Platform
                    }, new List<ApiLimit>()
                    {
                        new ApiLimit(new TimeSpan(0,1,0),400, RateLimitType.MethodRate),
                        new ApiLimit(new TimeSpan(0, 2, 0), 100, RateLimitType.AppRate),
                        new ApiLimit(new TimeSpan(0, 0, 1), 20, RateLimitType.AppRate)
                    }, LolApiMethodName.Champions,
                    LolApiMethodName.Masteries,
                    LolApiMethodName.Runes);

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