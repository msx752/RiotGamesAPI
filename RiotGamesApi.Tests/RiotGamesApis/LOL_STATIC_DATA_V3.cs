using System.Collections.Generic;
using RiotGamesApi.Enums;
using RiotGamesApi.Library.v3.StaticEndPoints.Champions;
using RiotGamesApi.Library.v3.StaticEndPoints.Items;
using RiotGamesApi.Library.v3.StaticEndPoints.LanguageStrings;
using RiotGamesApi.Library.v3.StaticEndPoints.Maps;
using RiotGamesApi.Library.v3.StaticEndPoints.Masteries;
using RiotGamesApi.Library.v3.StaticEndPoints.Realms;
using RiotGamesApi.Library.v3.StaticEndPoints.Runes;
using RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell;
using RiotGamesApi.Models;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
    public class LOL_STATIC_DATA_V3 : BaseTestClass
    {
        [Fact]
        public void GetChampions()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionListDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Champions)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetChampionsOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<ChampionDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Champions)
                .AddParameter(new ApiParameter(LolApiPath.OnlyId, ChampionId))
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetItems()
        {
            var rit = new ApiCall()
                .SelectApi<ItemListDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Champions)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetItemsOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<ItemDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Items)
                .AddParameter(new ApiParameter(LolApiPath.OnlyId, ItemId))
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetLanguageStrings()
        {
            var rit = new ApiCall()
                .SelectApi<LanguageStringsDto>(LolApiName.StaticData)
                .For(LolApiMethodName.LanguageStrings)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetLanguages()
        {
            var rit = new ApiCall()
                .SelectApi<List<string>>(LolApiName.StaticData)
                .For(LolApiMethodName.Languages)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMaps()
        {
            var rit = new ApiCall()
                .SelectApi<MapDataDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Maps)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMasteries()
        {
            var rit = new ApiCall()
                .SelectApi<MasteryListDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Masteries)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetMasteriesOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<MasteryDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Masteries)
                .AddParameter(new ApiParameter(LolApiPath.OnlyId, MasteryId))
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetRealms()
        {
            var rit = new ApiCall()
                .SelectApi<RealmDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Realms)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetRunes()
        {
            var rit = new ApiCall()
                .SelectApi<RuneListDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Runes)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetRunesOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<RuneDto>(LolApiName.StaticData)
                .For(LolApiMethodName.Runes)
                .AddParameter(new ApiParameter(LolApiPath.OnlyId, (long)1))
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetSummonerSpells()
        {
            var rit = new ApiCall()
                .SelectApi<SummonerSpellListDto>(LolApiName.StaticData)
                .For(LolApiMethodName.SummonerSpells)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetSummonerSpellsOnlyId()
        {
            var rit = new ApiCall()
                .SelectApi<SummonerSpellDto>(LolApiName.StaticData)
                .For(LolApiMethodName.SummonerSpells)
                .AddParameter(new ApiParameter(LolApiPath.OnlyId, (long)1))
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }

        [Fact]
        public void GetVersions()
        {
            var rit = new ApiCall()
                .SelectApi<List<string>>(LolApiName.StaticData)
                .For(LolApiMethodName.Versions)
                .AddParameter()
                .Build(Service_Platform)
                .UseCache(false)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}