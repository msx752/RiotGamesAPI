using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using RiotGamesApi;
using RiotGamesApi.AspNet;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.RateLimit;

[assembly: OwinStartupAttribute(typeof(RiotGamesApi.AspNet.Web.Startup))]

namespace RiotGamesApi.AspNet.Web
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var services = new ServiceCollection();
			ConfigureAuth(app);
			ConfigureRiotGamesApi(app, services);
		}

		public void ConfigureRiotGamesApi(IAppBuilder app, IServiceCollection services)
		{
			//necessary
			services.AddLeagueOfLegendsApi("RGAPI-300f08b5-ac70-49d8-a5e5-b7c0eedf0fe4",
			(cache) =>
			{
				//overrides default values
				cache.EnableStaticApiCaching = true;
				cache.StaticApiCacheExpiry = new TimeSpan(1, 0, 0);

				//custom caching is activated
				//working for any api except static-api
				cache.EnableCustomApiCaching = true;
				//summoner-profiles are cached for 5sec
				cache.AddCacheRule(LolUrlType.NonStatic, LolApiName.Summoner, new TimeSpan(0, 0, 5));
				return cache;
			},
			(limits) =>
			{
				limits.AddRateLimitFor(LolUrlType.Static, LolApiName.StaticData,
					new List<ApiLimit>()
					{
						new ApiLimit(new TimeSpan(1, 0, 0), 10, RateLimitType.MethodRate)
					}, LolApiMethodName.Champions,
					LolApiMethodName.Items,
					LolApiMethodName.LanguageStrings,
					LolApiMethodName.LanguageStrings,
					LolApiMethodName.Maps,
					LolApiMethodName.Masteries,
					LolApiMethodName.ProfileIcons,
					LolApiMethodName.Realms,
					LolApiMethodName.Runes,
					LolApiMethodName.SummonerSpells,
					LolApiMethodName.Versions);

				limits.AddRateLimitFor(LolUrlType.NonStatic, LolApiName.Match,
					new List<ApiLimit>()
					{
						new ApiLimit(new TimeSpan(0, 0, 10),500, RateLimitType.MethodRate)
					}, LolApiMethodName.Matches, LolApiMethodName.Timelines);

				limits.AddRateLimitFor(LolUrlType.NonStatic, LolApiName.Match,
					new List<ApiLimit>()
					{
						new ApiLimit(new TimeSpan(0, 0, 10),1000, RateLimitType.MethodRate)
					}, LolApiMethodName.MatchLists);

				limits.AddRateLimitFor(LolUrlType.Status, LolApiName.Status, new List<ApiLimit>()
				{
					new ApiLimit(new TimeSpan(0, 0, 10), 20000, RateLimitType.MethodRate),
					new ApiLimit(new TimeSpan(0, 2, 0), 100, RateLimitType.AppRate),
					new ApiLimit(new TimeSpan(0, 0, 1), 20, RateLimitType.AppRate)
				}, LolApiMethodName.ShardData);

				limits.AddRateLimitFor(LolUrlType.Tournament, new List<LolApiName>()
					 {
						LolApiName.Tournament,
						LolApiName.TournamentStub
					 }, new List<ApiLimit>()
					 {
						new ApiLimit(new TimeSpan(0, 0, 10), 20000, RateLimitType.MethodRate),
						new ApiLimit(new TimeSpan(0, 2, 0), 100, RateLimitType.AppRate),
						new ApiLimit(new TimeSpan(0, 0, 1), 20, RateLimitType.AppRate)
					 },
					LolApiMethodName.Codes,
					LolApiMethodName.LobbyEvents,
					LolApiMethodName.Providers,
					LolApiMethodName.Tournaments);

				limits.AddRateLimitFor(LolUrlType.NonStatic, new List<LolApiName>()
					{
						LolApiName.ChampionMastery,
						LolApiName.Spectator,
						//LolApiName.Summoner,
						LolApiName.Platform,
					}, new List<ApiLimit>()
					{
						new ApiLimit(new TimeSpan(0, 0, 10), 20000, RateLimitType.MethodRate),
						new ApiLimit(new TimeSpan(0, 2, 0), 100, RateLimitType.AppRate),
						new ApiLimit(new TimeSpan(0, 0, 1), 20, RateLimitType.AppRate)
					},
					LolApiMethodName.ChampionMasteries,
					LolApiMethodName.Scores,
					LolApiMethodName.ActiveGames,
					LolApiMethodName.FeaturedGames,
					LolApiMethodName.Summoners
				);

				//lol/platform/v3/champions
				//lol/platform/v3/masteries/by-summoner/{summonerId}
				//lol/platform/v3/runes/by-summoner/{summonerId}
				limits.AddRateLimitFor(LolUrlType.NonStatic, new List<LolApiName>()
					{
						LolApiName.Platform
					}, new List<ApiLimit>()
					{
						new ApiLimit(new TimeSpan(0,1,0),400, RateLimitType.MethodRate),
						new ApiLimit(new TimeSpan(0, 2, 0), 100, RateLimitType.AppRate),
						new ApiLimit(new TimeSpan(0, 0, 1), 20, RateLimitType.AppRate)
					}, LolApiMethodName.Champions,
					LolApiMethodName.Masteries,
					LolApiMethodName.Runes);

				limits.LeaguesApiLimitsInMinute();
				limits.SummonerIdAndByNameLimitsInMinute();
				limits.SummonerAccountNameLimitsInMinute();
				return limits;
			});

			app.UseRiotGamesApi(services);
		}
	}
}