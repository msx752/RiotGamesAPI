using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Summoner;
using RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Champions;
using RiotGamesApi.Models;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
	public class API_CACHE : BaseTestClass
	{
		[Fact]
		public void CacheStaticApi()
		{
			var rit = new ApiCall()
				.SelectApi<ChampionListDto>(LolApiName.StaticData)
				.For(LolApiMethodName.Champions)
				.AddParameter()
				.Build(Service_Platform)
				.UseCache(true)
				.Get();
			Assert.False(rit.HasError);
			Assert.False(rit.IsCache);

			rit = new ApiCall()
				.SelectApi<ChampionListDto>(LolApiName.StaticData)
				.For(LolApiMethodName.Champions)
				.AddParameter()
				.Build(Service_Platform)
				.UseCache(true)
				.Get();
			Assert.False(rit.HasError);
			Assert.True(rit.IsCache);
		}

		[Fact]
		public void CacheNontify()
		{
			var rit = new ApiCall()
				.SelectApi<SummonerDto>(LolApiName.Summoner)
				.For(LolApiMethodName.Summoners)
				.AddParameter(new ApiParameter(LolApiPath.ByAccount, AccountId))
				.Build(Service_Platform)
				.UseCache(true, true)
				.Get();
			Assert.True(rit.CurrentXAppRateLimit == "cached" && rit.CurrentXMethodRateLimit == "cached" && rit.HasError == false);

			rit = new ApiCall()
			   .SelectApi<SummonerDto>(LolApiName.Summoner)
			   .For(LolApiMethodName.Summoners)
			   .AddParameter(new ApiParameter(LolApiPath.ByAccount, AccountId))
			   .Build(Service_Platform)
			   .UseCache(false, false)
			   .Get();
			Assert.False(rit.CurrentXAppRateLimit == "cached" && rit.CurrentXMethodRateLimit == "cached" && rit.HasError == false);
		}

		[Fact]
		public void CacheNonStaticApi()
		{
			var rit = LolApi.NonStaticApi.Summonerv3
				.GetSummonersByAccount(ServicePlatform.EUW1, AccountId);
			Assert.False(rit.HasError);
			Assert.False(rit.IsCache);

			rit = LolApi.NonStaticApi.Summonerv3
				.GetSummonersByAccount(ServicePlatform.EUW1, AccountId);
			Assert.False(rit.HasError);
			Assert.True(rit.IsCache);
		}
	}
}