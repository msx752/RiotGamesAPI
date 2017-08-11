using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.Library;
using RiotGamesApi.Library.Enums;
using RiotGamesApi.RateLimit;

namespace RiotGamesApi.Tests.Others
{
    public class BaseTestClass
    {
        private readonly ServiceRegion _serviceRegion;
        private readonly ServicePlatform _servicePlatform;
        public long AccountId { get; }
        public AspNetCoreTestServer AspNetCoreTestServer { get; }

        public long ChampionId { get; }

        public IConfigurationRoot Configuration { get; }
        public long MatchId { get; }
        public long ItemId { get; }

        public ServiceRegion Service_Region
        {
            get { return _serviceRegion; }
        }

        public ServicePlatform Service_Platform
        {
            get { return _servicePlatform; }
        }

        public long SummonerId { get; }

        public string SummonerName { get; }
        public string TournamentCode { get; }

        public long MasteryId { get; }

        public Api LolApi
        {
            get { return (Api)ApiSettings.ServiceProvider.GetService(typeof(Api)); }
        }

        public ApiRate ApiRateLimiting
        {
            get { return (ApiRate)ApiSettings.ServiceProvider.GetService(typeof(ApiRate)); }
        }

        public BaseTestClass()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(Directory.GetCurrentDirectory() + "\\appsettings.json",
                    optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            ChampionId = long.Parse(Configuration["championId"]);

            MatchId = long.Parse(Configuration["matchId"]);

            ItemId = long.Parse(Configuration["itemId"]);

            _serviceRegion = (ServiceRegion)Enum.Parse(typeof(ServiceRegion), Configuration["region"]);

            _servicePlatform = Service_Region.ToPlatform();

            SummonerId = long.Parse(Configuration["summonerId"]);

            SummonerName = Configuration["summonerName"];

            AccountId = long.Parse(Configuration["accountId"]);

            TournamentCode = Configuration["tournamentCode"];

            MasteryId = long.Parse(Configuration["masteryId"]);

            AspNetCoreTestServer = new AspNetCoreTestServer();
        }
    }
}