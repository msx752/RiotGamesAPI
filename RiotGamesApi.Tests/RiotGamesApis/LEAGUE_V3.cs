using System.Collections.Generic;
using RiotGamesApi.Enums;
using RiotGamesApi.Library.Enums.GameConstants;
using RiotGamesApi.Library.v3.NonStaticEndPoints.League;
using RiotGamesApi.Models;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
    public class LEAGUE_V3 : BaseTestClass
    {
        [Fact]
        public void GetChallengerLeagues()
        {
            var rit = new ApiCall()
                .SelectApi<LeagueListDTO>(LolApiName.League)
                .For(LolApiMethodName.ChallengerLeagues)
                .AddParameter(new ApiParameter(LolApiPath.ByQueue, MatchMakingQueue.RANKED_SOLO_5x5))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetLeagues()
        {
            var rit = new ApiCall()
                .SelectApi<List<LeagueListDTO>>(LolApiName.League)
                .For(LolApiMethodName.Leagues)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMasterLeagues()
        {
            var rit = new ApiCall()
                .SelectApi<LeagueListDTO>(LolApiName.League)
                .For(LolApiMethodName.MasterLeagues)
                .AddParameter(new ApiParameter(LolApiPath.ByQueue, MatchMakingQueue.RANKED_SOLO_5x5))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetPositions()
        {
            var rit = new ApiCall()
                .SelectApi<List<LeaguePositionDTO>>(LolApiName.League)
                .For(LolApiMethodName.Positions)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}