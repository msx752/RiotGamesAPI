using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Spectator;
using RiotGamesApi.Models;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
    public class SPECTATOR_V3 : BaseTestClass
    {
        [Fact]
        public void GetActiveGamesBySummoner()
        {
            var rit = new ApiCall()
                .SelectApi<CurrentGameInfo>(LolApiName.Spectator)
                .For(LolApiMethodName.ActiveGames)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(Service_Platform)
                .Get();
            if (rit.HasError)
                Assert.Equal("Data not found:404", rit.Exception.Message);
            else
                Assert.False(rit.HasError);
        }

        [Fact]
        public void GetFeaturedGames()
        {
            var rit = new ApiCall()
                .SelectApi<FeaturedGames>(LolApiName.Spectator)
                .For(LolApiMethodName.FeaturedGames)
                .AddParameter()
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}