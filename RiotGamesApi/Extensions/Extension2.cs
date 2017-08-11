using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using RiotGamesApi.Cache;
using RiotGamesApi.Enums;
using RiotGamesApi.Interfaces;
using RiotGamesApi.Library.Enums;
using RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery;
using RiotGamesApi.Library.v3.NonStaticEndPoints.League;
using RiotGamesApi.Library.v3.NonStaticEndPoints.Mastery;
using RiotGamesApi.Library.v3.NonStaticEndPoints.Match;
using RiotGamesApi.Library.v3.NonStaticEndPoints.Rune;
using RiotGamesApi.Library.v3.NonStaticEndPoints.Spectator;
using RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner;
using RiotGamesApi.Library.v3.StaticEndPoints.Champions;
using RiotGamesApi.Library.v3.StaticEndPoints.Items;
using RiotGamesApi.Library.v3.StaticEndPoints.LanguageStrings;
using RiotGamesApi.Library.v3.StaticEndPoints.Maps;
using RiotGamesApi.Library.v3.StaticEndPoints.Masteries;
using RiotGamesApi.Library.v3.StaticEndPoints.Profile;
using RiotGamesApi.Library.v3.StaticEndPoints.Realms;
using RiotGamesApi.Library.v3.StaticEndPoints.Runes;
using RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell;
using RiotGamesApi.Library.v3.StatusEndPoints;
using RiotGamesApi.Library.v3.TournamentEndPoints;
using RiotGamesApi.RateLimit;
using RiotGamesApi.RateLimit.Builder;
using MasteryDto = RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryDto;
using RuneDto = RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneDto;

namespace RiotGamesApi
{
    public static class Extension2
    {
        /// <summary>
        /// necessary for using LeagueOfLegendsApi 
        /// </summary>
        /// <param name="services">
        /// </param>
        /// <param name="riotApiKey">
        /// RiotGames DeveloperKey or ProductionKey 
        /// </param>
        /// <exception cref="Exception">
        /// A delegate callback throws an exception. 
        /// </exception>
        public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey)
        {
            AddLeagueOfLegendsApi(services, riotApiKey, null, null);
        }

        /// <summary>
        /// necessary for using LeagueOfLegendsApi 
        /// </summary>
        /// <param name="services">
        /// </param>
        /// <param name="riotApiKey">
        /// RiotGames DeveloperKey or ProductionKey 
        /// </param>
        /// <param name="cacheOption">
        /// custom api caching options (default: ApiCaching is NOT USED ) 
        /// </param>
        /// <exception cref="Exception">
        /// A delegate callback throws an exception. 
        /// </exception>
        public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey,
            Func<CacheOption, CacheOption> cacheOption)
        {
            AddLeagueOfLegendsApi(services, riotApiKey, cacheOption, null);
        }

        /// <exception cref="Exception">
        /// A delegate callback throws an exception. 
        /// </exception>
        public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey,
            Func<RateLimitData, RateLimitData> rateLimitOption2)
        {
            AddLeagueOfLegendsApi(services, riotApiKey, null, rateLimitOption2);
        }

        /// <summary>
        /// necessary for using LeagueOfLegendsApi 
        /// </summary>
        /// <param name="services">
        /// </param>
        /// <param name="riotApiKey">
        /// RiotGames DeveloperKey or ProductionKey 
        /// </param>
        /// <param name="cacheOption">
        /// [overrides all default values] custom api caching options (default: ApiCaching is NOT
        /// USED )
        /// </param>
        /// <param name="rateLimitOption2">
        /// [overrides all default values] custom rate limit handling options (default: rate-limiting
        /// is USED) default X-App-Rate-Limit: 100:120,20:1, default X-Method-Rate-Limit:
        /// 20000:10,1200000:600, default Mathlists X-Method-Rate-Limit: 500:10
        /// </param>
        /// <exception cref="Exception">
        /// A delegate callback throws an exception. 
        /// </exception>
        public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey,
            Func<CacheOption, CacheOption> cacheOption,
            Func<RateLimitData, RateLimitData> rateLimitOption2)
        {
            //can convertable to json
            var riotGamesApiBuilder = RiotGamesApiBuilder(riotApiKey);
            var riotGamesApiOption = riotGamesApiBuilder.Build();

            var cOptions = new CacheOption();
            riotGamesApiOption.CacheOptions = cacheOption != null ? cacheOption(cOptions) : cOptions;

            RateLimitData limits = RateLimitData();//default settings
            if (rateLimitOption2 != null)
            {
                limits = rateLimitOption2(limits); //user settings
            }

            RateLimitBuilder rlb = RateLimitBuilder(limits);//default settings
            riotGamesApiOption.RateLimitOptions.All = rlb.Build();
            riotGamesApiOption.RateLimitOptions.DisableLimiting = limits.DisableLimiting;

            services.AddSingleton<IApiOption>(riotGamesApiOption);
            services.AddMemoryCache();
            services.AddSingleton<IApiCache>(new ApiCache());
            services.AddSingleton<Api>(new Api());
            services.AddSingleton<ApiRate>(new ApiRate());
        }

        private static RateLimitData RateLimitData()
        {
            RateLimitData limits = new RateLimitData();
            limits.DisableLimiting = false;
            limits.AddXAppRateLimits(new Dictionary<TimeSpan, int>()
            {
                {new TimeSpan(0, 2, 0), 100 },
                {new TimeSpan(0, 0, 1), 20 }
            });
            return limits;
        }

        private static IApiBuilder RiotGamesApiBuilder(string riotApiKey)
        {
            var riotGamesApiBuilder = ((IApiBuilder)new RiotGamesApiBuilder())
                .UseRiotApiKey(riotApiKey)
                .UseApiUrl("api.riotgames.com")
                .UseStatusApi((apis) =>
                {
                    apis.AddApi(LolApiName.Status, 3)
                        .GetMethod(LolApiMethodName.ShardData, typeof(ShardStatus));
                    return apis;
                })
                .UseStaticApi((apis) =>
                {
                    apis.AddApi(LolApiName.StaticData, 3.0)
                        .GetMethod(LolApiMethodName.Champions, typeof(ChampionListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ChampionTag>)},
                            {"dataById",typeof(bool)},
                        })
                        .GetMethod(LolApiMethodName.Champions, typeof(ChampionDto), LolApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ChampionTag>)},
                            {"dataById",typeof(bool)},
                        })
                        .GetMethod(LolApiMethodName.Items, typeof(ItemListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ItemTag>)},
                        })
                        .GetMethod(LolApiMethodName.Items, typeof(ItemDto), LolApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<ItemTag>)},
                        })
                        .GetMethod(LolApiMethodName.LanguageStrings, typeof(LanguageStringsDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetMethod(LolApiMethodName.Languages, typeof(List<string>))
                        .GetMethod(LolApiMethodName.Maps, typeof(MapDataDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetMethod(LolApiMethodName.Masteries, typeof(MasteryListDto)).AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<MasteryTag>)},
                        })
                        .GetMethod(LolApiMethodName.Masteries, typeof(MasteryDto), LolApiPath.OnlyId).AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<MasteryTag>)},
                        })
                        .GetMethod(LolApiMethodName.ProfileIcons, typeof(ProfileIconDataDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                        })
                        .GetMethod(LolApiMethodName.Realms, typeof(RealmDto))
                        .GetMethod(LolApiMethodName.Runes, typeof(RuneListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<RuneTag>)},
                        })
                        .GetMethod(LolApiMethodName.Runes, typeof(RuneDto), LolApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"tags",typeof(List<RuneTag>)},
                        })
                        .GetMethod(LolApiMethodName.SummonerSpells, typeof(SummonerSpellListDto))
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"dataById",typeof(bool) },
                            {"tags",typeof(List<SummonerSpellTag>) }
                        })
                        .GetMethod(LolApiMethodName.SummonerSpells, typeof(SummonerSpellDto), LolApiPath.OnlyId)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"locale",typeof(string)},
                            {"version",typeof(string)},
                            {"dataById",typeof(bool) },
                            {"tags",typeof(List<SummonerSpellTag>) }
                        })
                        .GetMethod(LolApiMethodName.Versions, typeof(List<string>));
                    return apis;
                })
                .UseNonStaticApi(apis =>
                {
                    apis.AddApi(LolApiName.ChampionMastery, 3.0)
                        .GetMethod(LolApiMethodName.ChampionMasteries, typeof(List<ChampionMasteryDto>), LolApiPath.BySummoner)
                        .GetMethod(LolApiMethodName.ChampionMasteries, typeof(ChampionMasteryDto), LolApiPath.BySummoner, LolApiPath.ByChampion)
                        .GetMethod(LolApiMethodName.Scores, typeof(int), LolApiPath.BySummoner);

                    apis.AddApi(LolApiName.Summoner, 3.0)
                        .GetMethod(LolApiMethodName.Summoners, typeof(SummonerDto), LolApiPath.ByAccount)
                        .GetMethod(LolApiMethodName.Summoners, typeof(SummonerDto), LolApiPath.ByName)
                        .GetMethod(LolApiMethodName.Summoners, typeof(SummonerDto), LolApiPath.OnlySummonerId);

                    apis.AddApi(LolApiName.Platform, 3.0)
                        .GetMethod(LolApiMethodName.Champions, typeof(Library.v3.NonStaticEndPoints.Champion.ChampionListDto))
                        .GetMethod(LolApiMethodName.Champions, typeof(Library.v3.NonStaticEndPoints.Champion.ChampionDto), LolApiPath.OnlyId)
                        .GetMethod(LolApiMethodName.Masteries, typeof(MasteryPagesDto), LolApiPath.BySummoner)
                        .GetMethod(LolApiMethodName.Runes, typeof(RunePagesDto), LolApiPath.BySummoner);

                    apis.AddApi(LolApiName.League, 3.0)
                        .GetMethod(LolApiMethodName.ChallengerLeagues, typeof(LeagueListDTO), LolApiPath.ByQueue)
                        .GetMethod(LolApiMethodName.Leagues, typeof(List<LeagueListDTO>), LolApiPath.BySummoner)
                        .GetMethod(LolApiMethodName.MasterLeagues, typeof(LeagueListDTO), LolApiPath.ByQueue)
                        .GetMethod(LolApiMethodName.Positions, typeof(List<LeaguePositionDTO>), LolApiPath.BySummoner);

                    //// "version 3.1 testing (NOT WORKS only for displaying)
                    //apis.AddApi(LolApiName.League, 3.1)
                    //    .GetMethod(LolApiMethodName.ChallengerLeagues, typeof(RiotApi.v31.Empty), LolApiPath.ByQueue);
                    ////

                    apis.AddApi(LolApiName.Match, 3.0)
                        .GetMethod(LolApiMethodName.Matches, typeof(MatchDto), LolApiPath.OnlyMatchId)
                        .GetMethod(LolApiMethodName.MatchLists, typeof(MatchlistDto), LolApiPath.ByAccount)
                        .GetMethod(LolApiMethodName.MatchLists, typeof(MatchlistDto), LolApiPath.ByAccountRecent)
                        .GetMethod(LolApiMethodName.Timelines, typeof(MatchTimelineDto), LolApiPath.ByMatch)
                        .GetMethod(LolApiMethodName.Matches, typeof(List<long>), LolApiPath.ByTournamentCodeIds)
                        .GetMethod(LolApiMethodName.Matches, typeof(MatchDto), LolApiPath.OnlyMatchId, LolApiPath.ByTournamentCode);

                    apis.AddApi(LolApiName.Spectator, 3.0)
                        .GetMethod(LolApiMethodName.ActiveGames, typeof(CurrentGameInfo), LolApiPath.BySummoner)
                        .GetMethod(LolApiMethodName.FeaturedGames, typeof(FeaturedGames));

                    return apis;
                })
                .UseTournamentApi((apis) =>
                {
                    apis.AddApi(LolApiName.TournamentStub, 3.0)
                        .PostMethod(LolApiMethodName.Codes, typeof(List<string>), typeof(TournamentCodeParameters), false)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"count", typeof(int)},
                            {"tournamentId", typeof(int)}
                        })
                        .GetMethod(LolApiMethodName.LobbyEvents, typeof(LobbyEventDTOWrapper), LolApiPath.ByCode)
                        .PostMethod(LolApiMethodName.Providers, typeof(int), typeof(ProviderRegistrationParameters), true)
                        .PostMethod(LolApiMethodName.Tournaments, typeof(int), typeof(TournamentRegistrationParameters), true);

                    apis.AddApi(LolApiName.Tournament, 3.0)
                        .PostMethod(LolApiMethodName.Codes, typeof(List<string>), typeof(RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeParameters), true)
                        .AddQueryParameter(new Dictionary<string, Type>()
                        {
                            {"count", typeof(int)},
                            {"tournamentId", typeof(int)}
                        })
                        .PutMethod(LolApiMethodName.Codes, typeof(TournamentCodeUpdateParameters), false, LolApiPath.OnlyTournamentCode)
                        .GetMethod(LolApiMethodName.Codes, typeof(TournamentCodeDTO), LolApiPath.OnlyTournamentCode)
                        .GetMethod(LolApiMethodName.LobbyEvents, typeof(RiotGamesApi.Library.v3.TournamentEndPoints.LobbyEventDTOWrapper), LolApiPath.ByCode)
                        .PostMethod(LolApiMethodName.Providers, typeof(int), typeof(RiotGamesApi.Library.v3.TournamentEndPoints.ProviderRegistrationParameters), true)
                        .PostMethod(LolApiMethodName.Tournaments, typeof(int), typeof(RiotGamesApi.Library.v3.TournamentEndPoints.TournamentRegistrationParameters), true);

                    return apis;
                });
            return riotGamesApiBuilder;
        }

        private static RateLimitBuilder RateLimitBuilder(RateLimitData limits)
        {
            RateLimitBuilder rlb = new RateLimitBuilder();
            rlb.AddRateLimitFor(LolUrlType.Static, LolApiName.StaticData,
                new List<ApiLimit>()
                {
                    new ApiLimit(new TimeSpan(1,0,0),10,RateLimitType.MethodRate)
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

            rlb.AddRateLimitFor(LolUrlType.NonStatic, LolApiName.Match,
                new List<ApiLimit>()
                {
                    new ApiLimit(new TimeSpan(0,0,10),500, RateLimitType.MethodRate)
                }, LolApiMethodName.Matches, LolApiMethodName.Timelines);

            rlb.AddRateLimitFor(LolUrlType.NonStatic, LolApiName.Match,
                new List<ApiLimit>()
                {
                    new ApiLimit(new TimeSpan(0,0,10),1000, RateLimitType.MethodRate)
                }, LolApiMethodName.MatchLists);

            List<ApiLimit> allOtherEndpointsMethodLimits = new List<ApiLimit>();
            allOtherEndpointsMethodLimits.Add(new ApiLimit(new TimeSpan(0, 0, 10), 20000, RateLimitType.MethodRate));

            var mergedLimits = limits.GetXAppRateLimit();
            mergedLimits.AddRange(allOtherEndpointsMethodLimits);

            rlb.AddRateLimitFor(LolUrlType.Status, LolApiName.Status, allOtherEndpointsMethodLimits, LolApiMethodName.ShardData);

            rlb.AddRateLimitFor(LolUrlType.Tournament, new List<LolApiName>()
                {
                    LolApiName.Tournament,
                    LolApiName.TournamentStub
                }, mergedLimits,
                LolApiMethodName.Codes,
                LolApiMethodName.LobbyEvents,
                LolApiMethodName.Providers,
                LolApiMethodName.Tournaments);

            rlb.AddRateLimitFor(LolUrlType.NonStatic, new List<LolApiName>()
                {
                    LolApiName.ChampionMastery,
                    LolApiName.League,
                    LolApiName.Spectator,
                    LolApiName.Summoner,
                    LolApiName.Platform,
                }, mergedLimits,
                LolApiMethodName.ChampionMasteries,
                LolApiMethodName.Scores,
                LolApiMethodName.ChallengerLeagues,
                LolApiMethodName.Leagues,
                LolApiMethodName.MasterLeagues,
                LolApiMethodName.Positions,
                LolApiMethodName.ActiveGames,
                LolApiMethodName.FeaturedGames,
                LolApiMethodName.Summoners,
                LolApiMethodName.Runes,
                LolApiMethodName.Masteries,
                LolApiMethodName.Champions
            );
            return rlb;
        }

        /// <summary>
        /// necessary for using RiotGamesApi wrapper 
        /// </summary>
        /// <param name="app">
        /// </param>
        /// <returns>
        /// </returns>
        public static IServiceProvider UseRiotGamesApiServiceProvider(this IServiceProvider sProvider)
        {
            ApiSettings.ServiceProvider = sProvider;
            return sProvider;
        }
    }
}