using System.Collections.Generic;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.Library.Enums;
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
            Api p = new Api();
            var champions = await LolApi.StaticApi.StaticDatav3.GetChampionsAsync(ServicePlatform.EUW1, false, null, null,
                new List<ChampionTag>() { ChampionTag.all }, true);
            Assert.False(champions.HasError);
        }
    }
}