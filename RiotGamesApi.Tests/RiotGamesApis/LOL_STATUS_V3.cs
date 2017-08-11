using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.v3.StatusEndPoints;
using RiotGamesApi.Models;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
    public class LOL_STATUS_V3 : BaseTestClass
    {
        [Fact]
        public void GetStatus()
        {
            var rit = new ApiCall()
                .SelectApi<ShardStatus>(LolApiName.Status)
                .For(LolApiMethodName.ShardData)
                .AddParameter()
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}