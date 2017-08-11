using System.Collections.Generic;
using RiotGamesApi.Enums;
using RiotGamesApi.Library.Enums;
using RiotGamesApi.Library.v3.TournamentEndPoints;
using RiotGamesApi.Models;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
    public class TOURNAMENT_STUB_V3 : BaseTestClass
    {
        [Fact]
        public void GetLobbyEvents()//NOT TESTED
        {
            var rit = new ApiCall()
                .SelectApi<LobbyEventDTOWrapper>(LolApiName.TournamentStub)
                .For(LolApiMethodName.LobbyEvents)
                .AddParameter(new ApiParameter(LolApiPath.ByCode, TournamentCode))
                .Build(PhysicalRegion.americas)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void PostCodes()//NOT TESTED
        {
            var rit = new ApiCall()
                .SelectApi<List<string>>(LolApiName.TournamentStub)
                .For(LolApiMethodName.Codes)
                .AddParameter()
                .Build(PhysicalRegion.americas)
                .Post(new TournamentCodeParameters() { },
                new QueryParameter("count", 1),
                    new QueryParameter("tournamentId", 1));
            Assert.False(rit.HasError);
        }

        [Fact]
        public void PostProviders()//NOT TESTED
        {
            var rit = new ApiCall()
             .SelectApi<int>(LolApiName.TournamentStub)
             .For(LolApiMethodName.Providers)
             .AddParameter()
             .Build(PhysicalRegion.americas)
             .Post(new ProviderRegistrationParameters() { });
            Assert.False(rit.HasError);
        }

        [Fact]
        public void PostTournaments()//NOT TESTED
        {
            var rit = new ApiCall()
                .SelectApi<int>(LolApiName.TournamentStub)
                .For(LolApiMethodName.Tournaments)
                .AddParameter()
                .Build(PhysicalRegion.americas)
                .Post(new TournamentRegistrationParameters() { });
            Assert.False(rit.HasError);
        }
    }
}