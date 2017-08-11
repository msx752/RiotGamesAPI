using System.Collections.Generic;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.Libraries.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using Xunit;

namespace RiotGamesApi.Tests.Others.Tests
{
    public class UsingStaticApiClass : BaseTestClass
    {
        [Fact]
        public void Using()
        {
            var champions = LolApi.StaticApi.StaticDatav3.GetChampions(ServicePlatform.EUW1, false, null, null,
                  new List<ChampionTag>() { ChampionTag.all }, true);
            Assert.False(champions.HasError);
        }

        [Fact]
        public async void UsingAsync()
        {
            LolApi p = new LolApi();
            var champions = await LolApi.StaticApi.StaticDatav3.GetChampionsAsync(ServicePlatform.EUW1, false, null, null,
                new List<ChampionTag>() { ChampionTag.all }, true);
            Assert.False(champions.HasError);
        }
    }
}