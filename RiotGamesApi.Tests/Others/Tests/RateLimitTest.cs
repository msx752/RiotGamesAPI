using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.RateLimit.Property;
using Xunit;

namespace RiotGamesApi.Tests.Others.Tests
{
    public class RateLimitTest : BaseTestClass
    {
        [Fact]
        public void DebugRespecToRegionLimits()//run with DebugMode
        {
            for (int i = 0; i < 25; i++)
            {
                var snx = LolApi.NonStaticApi.Leaguev3.GetLeaguesBySummoner(ServicePlatform.EUW1, SummonerId);
                Assert.False(snx.HasError);
            }
        }

        [Fact]
        public void DebugRespecToMethodLimits()
        {
            // IF YOU USE THIS METHOD YOU CAN NOT GET RESULT FROM SERVER WITH STATIC-API FOR SPECIFIED PLATFORM,
            //THIS IS ONLY TEST WHETHER RATE LIMIT WORKS

            //you need 10 free-slot request for TR1 and 1 free-slot request for NA1,
            //otherwise you will see notification message on the output console when you run DEBUG-MODE
            for (int i = 0; i < 10; i++)
            {
                var snx2 = LolApi.StaticApi.StaticDatav3.GetChampions(ServicePlatform.TR1);
            }
            var allowedRequest = LolApi.StaticApi.StaticDatav3.GetChampions(ServicePlatform.NA1);
            Assert.False(allowedRequest.HasError);

            var waitingOneHour = LolApi.StaticApi.StaticDatav3.GetChampions(ServicePlatform.TR1);
            Assert.False(waitingOneHour.HasError);
        }

        [Fact]
        public void RegionalApiLimitTesting()
        {
            int rateCountPerRegion = 15;
            Task.Run(() =>
            {
                List<Task> ts = new List<Task>();

                for (int j = 0; j < rateCountPerRegion; j++)
                {
                    ts.Add(Task.Run(() =>
                    {
                        ApiRateLimiting.Handle(new RateLimitProperties()
                        {
                            Platform = ServicePlatform.EUW1.ToString(),
                            ApiName = LolApiName.Match,
                            UrlType = LolUrlType.NonStatic,
                            ApiMethod = LolApiMethodName.Matches
                        });
                    }));

                    ts.Add(Task.Run(() =>
                    {
                        ApiRateLimiting.Handle(new RateLimitProperties()
                        {
                            Platform = ServicePlatform.EUW1.ToString(),
                            ApiName = LolApiName.Summoner,
                            UrlType = LolUrlType.NonStatic,
                            ApiMethod = LolApiMethodName.Summoners
                        });
                    }));

                    ts.Add(Task.Run(() =>
                    {
                        ApiRateLimiting.Handle(new RateLimitProperties()
                        {
                            Platform = ServicePlatform.NA1.ToString(),
                            ApiName = LolApiName.Summoner,
                            UrlType = LolUrlType.NonStatic,
                            ApiMethod = LolApiMethodName.Summoners
                        });
                    }));
                    ts.Add(Task.Run(() =>
                    {
                        ApiRateLimiting.Handle(new RateLimitProperties()
                        {
                            Platform = ServicePlatform.NA1.ToString(),
                            ApiName = LolApiName.Summoner,
                            UrlType = LolUrlType.NonStatic,
                            ApiMethod = LolApiMethodName.Summoners
                        });
                    }));
                }

                Task.WaitAll(ts.ToArray());
            }).Wait();

            var na1 = ApiRateLimiting.Rates.Find(ServicePlatform.NA1.ToString(), LolUrlType.NonStatic, LolApiName.Summoner, LolApiMethodName.Summoners);
            var c1 = na1.Limits.First().Counter;
            var euw1_first = ApiRateLimiting.Rates.Find(ServicePlatform.EUW1.ToString(), LolUrlType.NonStatic, LolApiName.Summoner, LolApiMethodName.Summoners);
            var c2 = euw1_first.Limits.First().Counter;
            Assert.Equal(c1, c2 * 2);

            var euw1_second = ApiRateLimiting.Rates.Find(ServicePlatform.EUW1.ToString(), LolUrlType.NonStatic, LolApiName.Match, LolApiMethodName.Matches);
            Assert.Equal(c2, euw1_second.Limits.First().Counter);

            var sn = ApiRateLimiting.FindRate(Service_Platform.ToString(), LolUrlType.NonStatic, LolApiName.Summoner, LolApiMethodName.Summoners);
            Assert.Equal(3, sn.Limits.Count(p => p.Counter == rateCountPerRegion));//there are app,service and method rate limits (or two app rate and one method rate :=) )
        }
    }
}