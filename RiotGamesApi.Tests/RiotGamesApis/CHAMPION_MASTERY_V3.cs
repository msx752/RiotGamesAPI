using System.Collections.Generic;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.ChampionMastery;
using RiotGamesApi.Models;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
    public class CHAMPION_MASTERY_V3 : BaseTestClass
    {
        [Fact]
        public void GetChampionMasteries()
        {
            var rit = new ApiCall()
                .SelectApi<List<ChampionMasteryDto>>(LolApiName.ChampionMastery)
                .For(LolApiMethodName.ChampionMasteries)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetChampionMastery()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionMasteryDto>(LolApiName.ChampionMastery)
                .For(LolApiMethodName.ChampionMasteries)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId),
                               new ApiParameter(LolApiPath.ByChampion, ChampionId))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetChampionScore()
        {
            var rit = new ApiCall()
                .SelectApi<int>(LolApiName.ChampionMastery)
                .For(LolApiMethodName.Scores)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}