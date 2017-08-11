using RiotGamesApi.Enums;
using RiotGamesApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotGamesApi.Library.Enums;
using RiotGamesApi.Library.Enums.GameConstants;

namespace RiotGamesApi
{
    // ReSharper disable InconsistentNaming
    //AUTO GENERATED CLASS DO NOT MODIFY
    public class Api
    {
        private Status _statusApi;
        public Status StatusApi { get { return _statusApi ?? (_statusApi = new Status()); } }
        private Static _staticApi;
        public Static StaticApi { get { return _staticApi ?? (_staticApi = new Static()); } }
        private NonStatic _nonstaticApi;
        public NonStatic NonStaticApi { get { return _nonstaticApi ?? (_nonstaticApi = new NonStatic()); } }
        private Tournament _tournamentApi;
        public Tournament TournamentApi { get { return _tournamentApi ?? (_tournamentApi = new Tournament()); } }
    }

    //Status API
    //"https://{platformId}.api.riotgames.com/lol
    public class Status
    {
        private Status_v3 _Statusv3;
        public Status_v3 Statusv3 { get { return _Statusv3 ?? (_Statusv3 = new Status_v3()); } }

        //"Status/v3
        public class Status_v3
        {
            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StatusEndPoints.ShardStatus> GetShardData(ServicePlatform platform)
            {
                var t = GetShardDataAsync(platform);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StatusEndPoints.ShardStatus> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StatusEndPoints.ShardStatus>> GetShardDataAsync(ServicePlatform platform)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StatusEndPoints.ShardStatus> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StatusEndPoints.ShardStatus>(LolApiName.Status, 3)
                    .For(LolApiMethodName.ShardData)
                    .AddParameter()
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }
        }
    }

    //Static API
    //"https://{platformId}.api.riotgames.com/lol
    public class Static
    {
        private StaticData_v3 _StaticDatav3;
        public StaticData_v3 StaticDatav3 { get { return _StaticDatav3 ?? (_StaticDatav3 = new StaticData_v3()); } }

        //"StaticData/v3
        public class StaticData_v3
        {
            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Champions.ChampionListDto> GetChampions(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
            {
                var t = GetChampionsAsync(platform, _useCache, _locale, _version, _tags, _dataById);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Champions.ChampionListDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Champions.ChampionListDto>> GetChampionsAsync(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Champions.ChampionListDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.Champions.ChampionListDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Champions)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version),
                        new QueryParameter("tags", string.Join("&tags=", _tags ?? new List<RiotGamesApi.Library.Enums.ChampionTag>())),
                        new QueryParameter("dataById", _dataById.ToString().ToLower())
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Champions.ChampionDto> GetChampionsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
            {
                var t = GetChampionsOnlyIdAsync(platform, _OnlyId, _useCache, _locale, _version, _tags, _dataById);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Champions.ChampionDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Champions.ChampionDto>> GetChampionsOnlyIdAsync(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.Enums.ChampionTag> _tags = null, Boolean _dataById = false)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Champions.ChampionDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.Champions.ChampionDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Champions)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version),
                        new QueryParameter("tags", string.Join("&tags=", _tags ?? new List<RiotGamesApi.Library.Enums.ChampionTag>())),
                        new QueryParameter("dataById", _dataById.ToString().ToLower())
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Items.ItemListDto> GetItems(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.Enums.ItemTag> _tags = null)
            {
                var t = GetItemsAsync(platform, _useCache, _locale, _version, _tags);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Items.ItemListDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Items.ItemListDto>> GetItemsAsync(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.Enums.ItemTag> _tags = null)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Items.ItemListDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.Items.ItemListDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Items)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version),
                        new QueryParameter("tags", string.Join("&tags=", _tags ?? new List<RiotGamesApi.Library.Enums.ItemTag>()))
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Items.ItemDto> GetItemsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.Enums.ItemTag> _tags = null)
            {
                var t = GetItemsOnlyIdAsync(platform, _OnlyId, _useCache, _locale, _version, _tags);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Items.ItemDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Items.ItemDto>> GetItemsOnlyIdAsync(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.Enums.ItemTag> _tags = null)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Items.ItemDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.Items.ItemDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Items)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version),
                        new QueryParameter("tags", string.Join("&tags=", _tags ?? new List<RiotGamesApi.Library.Enums.ItemTag>()))
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.LanguageStrings.LanguageStringsDto> GetLanguageStrings(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
            {
                var t = GetLanguageStringsAsync(platform, _useCache, _locale, _version);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.LanguageStrings.LanguageStringsDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.LanguageStrings.LanguageStringsDto>> GetLanguageStringsAsync(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.LanguageStrings.LanguageStringsDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.LanguageStrings.LanguageStringsDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.LanguageStrings)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version)
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<List<System.String>> GetLanguages(ServicePlatform platform, bool _useCache = false)
            {
                var t = GetLanguagesAsync(platform, _useCache);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<List<System.String>> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<List<System.String>>> GetLanguagesAsync(ServicePlatform platform, bool _useCache = false)
            {
                RiotGamesApi.Interfaces.IResult<List<System.String>> rit = await new ApiCall()
                    .SelectApi<List<System.String>>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Languages)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Maps.MapDataDto> GetMaps(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
            {
                var t = GetMapsAsync(platform, _useCache, _locale, _version);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Maps.MapDataDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Maps.MapDataDto>> GetMapsAsync(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Maps.MapDataDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.Maps.MapDataDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Maps)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version)
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryListDto> GetMasteries(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryTag> _tags = null)
            {
                var t = GetMasteriesAsync(platform, _useCache, _locale, _version, _tags);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryListDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryListDto>> GetMasteriesAsync(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryTag> _tags = null)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryListDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryListDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Masteries)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version),
                        new QueryParameter("tags", string.Join("&tags=", _tags ?? new List<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryTag>()))
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryDto> GetMasteriesOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryTag> _tags = null)
            {
                var t = GetMasteriesOnlyIdAsync(platform, _OnlyId, _useCache, _locale, _version, _tags);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryDto>> GetMasteriesOnlyIdAsync(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryTag> _tags = null)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Masteries)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version),
                        new QueryParameter("tags", string.Join("&tags=", _tags ?? new List<RiotGamesApi.Library.v3.StaticEndPoints.Masteries.MasteryTag>()))
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Profile.ProfileIconDataDto> GetProfileIcons(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
            {
                var t = GetProfileIconsAsync(platform, _useCache, _locale, _version);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Profile.ProfileIconDataDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Profile.ProfileIconDataDto>> GetProfileIconsAsync(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Profile.ProfileIconDataDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.Profile.ProfileIconDataDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.ProfileIcons)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version)
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Realms.RealmDto> GetRealms(ServicePlatform platform, bool _useCache = false)
            {
                var t = GetRealmsAsync(platform, _useCache);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Realms.RealmDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Realms.RealmDto>> GetRealmsAsync(ServicePlatform platform, bool _useCache = false)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Realms.RealmDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.Realms.RealmDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Realms)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneListDto> GetRunes(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneTag> _tags = null)
            {
                var t = GetRunesAsync(platform, _useCache, _locale, _version, _tags);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneListDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneListDto>> GetRunesAsync(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneTag> _tags = null)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneListDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneListDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Runes)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version),
                        new QueryParameter("tags", string.Join("&tags=", _tags ?? new List<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneTag>()))
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneDto> GetRunesOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneTag> _tags = null)
            {
                var t = GetRunesOnlyIdAsync(platform, _OnlyId, _useCache, _locale, _version, _tags);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneDto>> GetRunesOnlyIdAsync(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, List<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneTag> _tags = null)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Runes)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version),
                        new QueryParameter("tags", string.Join("&tags=", _tags ?? new List<RiotGamesApi.Library.v3.StaticEndPoints.Runes.RuneTag>()))
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellListDto> GetSummonerSpells(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
            {
                var t = GetSummonerSpellsAsync(platform, _useCache, _locale, _version, _dataById, _tags);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellListDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellListDto>> GetSummonerSpellsAsync(ServicePlatform platform, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellListDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellListDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.SummonerSpells)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version),
                        new QueryParameter("dataById", _dataById.ToString().ToLower()),
                        new QueryParameter("tags", string.Join("&tags=", _tags ?? new List<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellTag>()))
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellDto> GetSummonerSpellsOnlyId(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
            {
                var t = GetSummonerSpellsOnlyIdAsync(platform, _OnlyId, _useCache, _locale, _version, _dataById, _tags);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellDto>> GetSummonerSpellsOnlyIdAsync(ServicePlatform platform, Int64 _OnlyId, bool _useCache = false, String _locale = null, String _version = null, Boolean _dataById = false, List<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellTag> _tags = null)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellDto>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.SummonerSpells)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync(new QueryParameter("locale", _locale),
                        new QueryParameter("version", _version),
                        new QueryParameter("dataById", _dataById.ToString().ToLower()),
                        new QueryParameter("tags", string.Join("&tags=", _tags ?? new List<RiotGamesApi.Library.v3.StaticEndPoints.SummonerSpell.SummonerSpellTag>()))
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<List<System.String>> GetVersions(ServicePlatform platform, bool _useCache = false)
            {
                var t = GetVersionsAsync(platform, _useCache);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<List<System.String>> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<List<System.String>>> GetVersionsAsync(ServicePlatform platform, bool _useCache = false)
            {
                RiotGamesApi.Interfaces.IResult<List<System.String>> rit = await new ApiCall()
                    .SelectApi<List<System.String>>(LolApiName.StaticData, 3)
                    .For(LolApiMethodName.Versions)
                    .AddParameter()
                    .Build(platform)
                    .UseCache(_useCache)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }
        }
    }

    //NonStatic API
    //"https://{platformId}.api.riotgames.com/lol
    public class NonStatic
    {
        private ChampionMastery_v3 _ChampionMasteryv3;
        public ChampionMastery_v3 ChampionMasteryv3 { get { return _ChampionMasteryv3 ?? (_ChampionMasteryv3 = new ChampionMastery_v3()); } }

        //"ChampionMastery/v3
        public class ChampionMastery_v3
        {
            public RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> GetChampionMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                var t = GetChampionMasteriesBySummonerAsync(platform, _BySummoner);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>>> GetChampionMasteriesBySummonerAsync(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> rit = await new ApiCall()
                    .SelectApi<List<RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>>(LolApiName.ChampionMastery, 3)
                    .For(LolApiMethodName.ChampionMasteries)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto> GetChampionMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner, Int64 _ByChampion)
            {
                var t = GetChampionMasteriesBySummonerAsync(platform, _BySummoner, _ByChampion);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>> GetChampionMasteriesBySummonerAsync(ServicePlatform platform, Int64 _BySummoner, Int64 _ByChampion)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery.ChampionMasteryDto>(LolApiName.ChampionMastery, 3)
                    .For(LolApiMethodName.ChampionMasteries)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner),
                        new ApiParameter(LolApiPath.ByChampion, _ByChampion))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<Int32> GetScoresBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                var t = GetScoresBySummonerAsync(platform, _BySummoner);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<Int32> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<Int32>> GetScoresBySummonerAsync(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.Interfaces.IResult<Int32> rit = await new ApiCall()
                    .SelectApi<Int32>(LolApiName.ChampionMastery, 3)
                    .For(LolApiMethodName.Scores)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }
        }

        private Summoner_v3 _Summonerv3;
        public Summoner_v3 Summonerv3 { get { return _Summonerv3 ?? (_Summonerv3 = new Summoner_v3()); } }

        //"Summoner/v3
        public class Summoner_v3
        {
            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto> GetSummonersByAccount(ServicePlatform platform, Int64 _ByAccount)
            {
                var t = GetSummonersByAccountAsync(platform, _ByAccount);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto>> GetSummonersByAccountAsync(ServicePlatform platform, Int64 _ByAccount)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto>(LolApiName.Summoner, 3)
                    .For(LolApiMethodName.Summoners)
                    .AddParameter(new ApiParameter(LolApiPath.ByAccount, _ByAccount))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto> GetSummonersByName(ServicePlatform platform, String _ByName)
            {
                var t = GetSummonersByNameAsync(platform, _ByName);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto>> GetSummonersByNameAsync(ServicePlatform platform, String _ByName)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto>(LolApiName.Summoner, 3)
                    .For(LolApiMethodName.Summoners)
                    .AddParameter(new ApiParameter(LolApiPath.ByName, _ByName))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto> GetSummonersOnlySummonerId(ServicePlatform platform, Int64 _OnlySummonerId)
            {
                var t = GetSummonersOnlySummonerIdAsync(platform, _OnlySummonerId);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto>> GetSummonersOnlySummonerIdAsync(ServicePlatform platform, Int64 _OnlySummonerId)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Summoner.SummonerDto>(LolApiName.Summoner, 3)
                    .For(LolApiMethodName.Summoners)
                    .AddParameter(new ApiParameter(LolApiPath.OnlySummonerId, _OnlySummonerId))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }
        }

        private Platform_v3 _Platformv3;
        public Platform_v3 Platformv3 { get { return _Platformv3 ?? (_Platformv3 = new Platform_v3()); } }

        //"Platform/v3
        public class Platform_v3
        {
            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Champion.ChampionListDto> GetChampions(ServicePlatform platform)
            {
                var t = GetChampionsAsync(platform);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Champion.ChampionListDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Champion.ChampionListDto>> GetChampionsAsync(ServicePlatform platform)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Champion.ChampionListDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Champion.ChampionListDto>(LolApiName.Platform, 3)
                    .For(LolApiMethodName.Champions)
                    .AddParameter()
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Champion.ChampionDto> GetChampionsOnlyId(ServicePlatform platform, Int64 _OnlyId)
            {
                var t = GetChampionsOnlyIdAsync(platform, _OnlyId);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Champion.ChampionDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Champion.ChampionDto>> GetChampionsOnlyIdAsync(ServicePlatform platform, Int64 _OnlyId)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Champion.ChampionDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Champion.ChampionDto>(LolApiName.Platform, 3)
                    .For(LolApiMethodName.Champions)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Mastery.MasteryPagesDto> GetMasteriesBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                var t = GetMasteriesBySummonerAsync(platform, _BySummoner);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Mastery.MasteryPagesDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Mastery.MasteryPagesDto>> GetMasteriesBySummonerAsync(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Mastery.MasteryPagesDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Mastery.MasteryPagesDto>(LolApiName.Platform, 3)
                    .For(LolApiMethodName.Masteries)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Rune.RunePagesDto> GetRunesBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                var t = GetRunesBySummonerAsync(platform, _BySummoner);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Rune.RunePagesDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Rune.RunePagesDto>> GetRunesBySummonerAsync(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Rune.RunePagesDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Rune.RunePagesDto>(LolApiName.Platform, 3)
                    .For(LolApiMethodName.Runes)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }
        }

        private Platform_v3_1 _Platformv31;
        public Platform_v3_1 Platformv31 { get { return _Platformv31 ?? (_Platformv31 = new Platform_v3_1()); } }

        //"Platform/v3.1
        public class Platform_v3_1
        {
            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v31.NonStaticEndPoints.Champion.ChampionListDto> GetChampions(ServicePlatform platform)
            {
                var t = GetChampionsAsync(platform);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v31.NonStaticEndPoints.Champion.ChampionListDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v31.NonStaticEndPoints.Champion.ChampionListDto>> GetChampionsAsync(ServicePlatform platform)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v31.NonStaticEndPoints.Champion.ChampionListDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v31.NonStaticEndPoints.Champion.ChampionListDto>(LolApiName.Platform, 3.1)
                    .For(LolApiMethodName.Champions)
                    .AddParameter()
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v31.NonStaticEndPoints.Champion.ChampionDto> GetChampionsOnlyId(ServicePlatform platform, Int64 _OnlyId)
            {
                var t = GetChampionsOnlyIdAsync(platform, _OnlyId);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v31.NonStaticEndPoints.Champion.ChampionDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v31.NonStaticEndPoints.Champion.ChampionDto>> GetChampionsOnlyIdAsync(ServicePlatform platform, Int64 _OnlyId)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v31.NonStaticEndPoints.Champion.ChampionDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v31.NonStaticEndPoints.Champion.ChampionDto>(LolApiName.Platform, 3.1)
                    .For(LolApiMethodName.Champions)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyId, _OnlyId))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }
        }

        private League_v3 _Leaguev3;
        public League_v3 Leaguev3 { get { return _Leaguev3 ?? (_Leaguev3 = new League_v3()); } }

        //"League/v3
        public class League_v3
        {
            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO> GetChallengerLeaguesByQueue(ServicePlatform platform, MatchMakingQueue _ByQueue)
            {
                var t = GetChallengerLeaguesByQueueAsync(platform, _ByQueue);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO>> GetChallengerLeaguesByQueueAsync(ServicePlatform platform, MatchMakingQueue _ByQueue)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO>(LolApiName.League, 3)
                    .For(LolApiMethodName.ChallengerLeagues)
                    .AddParameter(new ApiParameter(LolApiPath.ByQueue, _ByQueue))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO>> GetLeaguesBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                var t = GetLeaguesBySummonerAsync(platform, _BySummoner);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO>> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO>>> GetLeaguesBySummonerAsync(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO>> rit = await new ApiCall()
                    .SelectApi<List<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO>>(LolApiName.League, 3)
                    .For(LolApiMethodName.Leagues)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO> GetMasterLeaguesByQueue(ServicePlatform platform, MatchMakingQueue _ByQueue)
            {
                var t = GetMasterLeaguesByQueueAsync(platform, _ByQueue);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO>> GetMasterLeaguesByQueueAsync(ServicePlatform platform, MatchMakingQueue _ByQueue)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeagueListDTO>(LolApiName.League, 3)
                    .For(LolApiMethodName.MasterLeagues)
                    .AddParameter(new ApiParameter(LolApiPath.ByQueue, _ByQueue))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeaguePositionDTO>> GetPositionsBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                var t = GetPositionsBySummonerAsync(platform, _BySummoner);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeaguePositionDTO>> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeaguePositionDTO>>> GetPositionsBySummonerAsync(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.Interfaces.IResult<List<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeaguePositionDTO>> rit = await new ApiCall()
                    .SelectApi<List<RiotGamesApi.Library.v3.NonStaticEndPoints.League.LeaguePositionDTO>>(LolApiName.League, 3)
                    .For(LolApiMethodName.Positions)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }
        }

        private Match_v3 _Matchv3;
        public Match_v3 Matchv3 { get { return _Matchv3 ?? (_Matchv3 = new Match_v3()); } }

        //"Match/v3
        public class Match_v3
        {
            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchDto> GetMatchesOnlyMatchId(ServicePlatform platform, Int64 _OnlyMatchId)
            {
                var t = GetMatchesOnlyMatchIdAsync(platform, _OnlyMatchId);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchDto>> GetMatchesOnlyMatchIdAsync(ServicePlatform platform, Int64 _OnlyMatchId)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchDto>(LolApiName.Match, 3)
                    .For(LolApiMethodName.Matches)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyMatchId, _OnlyMatchId))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchlistDto> GetMatchListsByAccount(ServicePlatform platform, Int64 _ByAccount)
            {
                var t = GetMatchListsByAccountAsync(platform, _ByAccount);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchlistDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchlistDto>> GetMatchListsByAccountAsync(ServicePlatform platform, Int64 _ByAccount)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchlistDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchlistDto>(LolApiName.Match, 3)
                    .For(LolApiMethodName.MatchLists)
                    .AddParameter(new ApiParameter(LolApiPath.ByAccount, _ByAccount))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchlistDto> GetMatchListsByAccountRecent(ServicePlatform platform, Int64 _ByAccountRecent)
            {
                var t = GetMatchListsByAccountRecentAsync(platform, _ByAccountRecent);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchlistDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchlistDto>> GetMatchListsByAccountRecentAsync(ServicePlatform platform, Int64 _ByAccountRecent)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchlistDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchlistDto>(LolApiName.Match, 3)
                    .For(LolApiMethodName.MatchLists)
                    .AddParameter(new ApiParameter(LolApiPath.ByAccountRecent, _ByAccountRecent))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchTimelineDto> GetTimelinesByMatch(ServicePlatform platform, Int64 _ByMatch)
            {
                var t = GetTimelinesByMatchAsync(platform, _ByMatch);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchTimelineDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchTimelineDto>> GetTimelinesByMatchAsync(ServicePlatform platform, Int64 _ByMatch)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchTimelineDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchTimelineDto>(LolApiName.Match, 3)
                    .For(LolApiMethodName.Timelines)
                    .AddParameter(new ApiParameter(LolApiPath.ByMatch, _ByMatch))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<List<System.Int64>> GetMatchesByTournamentCodeIds(ServicePlatform platform, String _ByTournamentCodeIds)
            {
                var t = GetMatchesByTournamentCodeIdsAsync(platform, _ByTournamentCodeIds);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<List<System.Int64>> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<List<System.Int64>>> GetMatchesByTournamentCodeIdsAsync(ServicePlatform platform, String _ByTournamentCodeIds)
            {
                RiotGamesApi.Interfaces.IResult<List<System.Int64>> rit = await new ApiCall()
                    .SelectApi<List<System.Int64>>(LolApiName.Match, 3)
                    .For(LolApiMethodName.Matches)
                    .AddParameter(new ApiParameter(LolApiPath.ByTournamentCodeIds, _ByTournamentCodeIds))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchDto> GetMatchesOnlyMatchId(ServicePlatform platform, Int64 _OnlyMatchId, String _ByTournamentCode)
            {
                var t = GetMatchesOnlyMatchIdAsync(platform, _OnlyMatchId, _ByTournamentCode);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchDto> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchDto>> GetMatchesOnlyMatchIdAsync(ServicePlatform platform, Int64 _OnlyMatchId, String _ByTournamentCode)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchDto> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Match.MatchDto>(LolApiName.Match, 3)
                    .For(LolApiMethodName.Matches)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyMatchId, _OnlyMatchId),
                        new ApiParameter(LolApiPath.ByTournamentCode, _ByTournamentCode))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }
        }

        private Spectator_v3 _Spectatorv3;
        public Spectator_v3 Spectatorv3 { get { return _Spectatorv3 ?? (_Spectatorv3 = new Spectator_v3()); } }

        //"Spectator/v3
        public class Spectator_v3
        {
            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Spectator.CurrentGameInfo> GetActiveGamesBySummoner(ServicePlatform platform, Int64 _BySummoner)
            {
                var t = GetActiveGamesBySummonerAsync(platform, _BySummoner);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Spectator.CurrentGameInfo> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Spectator.CurrentGameInfo>> GetActiveGamesBySummonerAsync(ServicePlatform platform, Int64 _BySummoner)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Spectator.CurrentGameInfo> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Spectator.CurrentGameInfo>(LolApiName.Spectator, 3)
                    .For(LolApiMethodName.ActiveGames)
                    .AddParameter(new ApiParameter(LolApiPath.BySummoner, _BySummoner))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Spectator.FeaturedGames> GetFeaturedGames(ServicePlatform platform)
            {
                var t = GetFeaturedGamesAsync(platform);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Spectator.FeaturedGames> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Spectator.FeaturedGames>> GetFeaturedGamesAsync(ServicePlatform platform)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.NonStaticEndPoints.Spectator.FeaturedGames> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.NonStaticEndPoints.Spectator.FeaturedGames>(LolApiName.Spectator, 3)
                    .For(LolApiMethodName.FeaturedGames)
                    .AddParameter()
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }
        }
    }

    //Tournament API
    //"https://{platformId}.api.riotgames.com/lol
    public class Tournament
    {
        private TournamentStub_v3 _TournamentStubv3;
        public TournamentStub_v3 TournamentStubv3 { get { return _TournamentStubv3 ?? (_TournamentStubv3 = new TournamentStub_v3()); } }

        //"TournamentStub/v3
        public class TournamentStub_v3
        {
            public RiotGamesApi.Interfaces.IResult<List<System.String>> PostCodes(PhysicalRegion platform, Int32? _count = null, Int32? _tournamentId = null, RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeParameters _tournamentcodeparameters = null)
            {
                var t = PostCodesAsync(platform, _count, _tournamentId, _tournamentcodeparameters);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<List<System.String>> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<List<System.String>>> PostCodesAsync(PhysicalRegion platform, Int32? _count = null, Int32? _tournamentId = null, RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeParameters _tournamentcodeparameters = null)
            {
                RiotGamesApi.Interfaces.IResult<List<System.String>> rit = await new ApiCall()
                    .SelectApi<List<System.String>>(LolApiName.TournamentStub, 3)
                    .For(LolApiMethodName.Codes)
                    .AddParameter()
                    .Build(platform)
                    .PostAsync(_tournamentcodeparameters,
                        new QueryParameter("count", _count),
                        new QueryParameter("tournamentId", _tournamentId)
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.LobbyEventDTOWrapper> GetLobbyEventsByCode(PhysicalRegion platform, String _ByCode)
            {
                var t = GetLobbyEventsByCodeAsync(platform, _ByCode);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.LobbyEventDTOWrapper> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.LobbyEventDTOWrapper>> GetLobbyEventsByCodeAsync(PhysicalRegion platform, String _ByCode)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.LobbyEventDTOWrapper> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.TournamentEndPoints.LobbyEventDTOWrapper>(LolApiName.TournamentStub, 3)
                    .For(LolApiMethodName.LobbyEvents)
                    .AddParameter(new ApiParameter(LolApiPath.ByCode, _ByCode))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<Int32> PostProviders(PhysicalRegion platform, RiotGamesApi.Library.v3.TournamentEndPoints.ProviderRegistrationParameters _providerregistrationparameters)
            {
                var t = PostProvidersAsync(platform, _providerregistrationparameters);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<Int32> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<Int32>> PostProvidersAsync(PhysicalRegion platform, RiotGamesApi.Library.v3.TournamentEndPoints.ProviderRegistrationParameters _providerregistrationparameters)
            {
                RiotGamesApi.Interfaces.IResult<Int32> rit = await new ApiCall()
                    .SelectApi<Int32>(LolApiName.TournamentStub, 3)
                    .For(LolApiMethodName.Providers)
                    .AddParameter()
                    .Build(platform)
                    .PostAsync(_providerregistrationparameters).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<Int32> PostTournaments(PhysicalRegion platform, RiotGamesApi.Library.v3.TournamentEndPoints.TournamentRegistrationParameters _tournamentregistrationparameters)
            {
                var t = PostTournamentsAsync(platform, _tournamentregistrationparameters);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<Int32> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<Int32>> PostTournamentsAsync(PhysicalRegion platform, RiotGamesApi.Library.v3.TournamentEndPoints.TournamentRegistrationParameters _tournamentregistrationparameters)
            {
                RiotGamesApi.Interfaces.IResult<Int32> rit = await new ApiCall()
                    .SelectApi<Int32>(LolApiName.TournamentStub, 3)
                    .For(LolApiMethodName.Tournaments)
                    .AddParameter()
                    .Build(platform)
                    .PostAsync(_tournamentregistrationparameters).ConfigureAwait(false);
                return rit;
            }
        }

        private Tournament_v3 _Tournamentv3;
        public Tournament_v3 Tournamentv3 { get { return _Tournamentv3 ?? (_Tournamentv3 = new Tournament_v3()); } }

        //"Tournament/v3
        public class Tournament_v3
        {
            public RiotGamesApi.Interfaces.IResult<List<System.String>> PostCodes(PhysicalRegion platform, RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeParameters _tournamentcodeparameters, Int32? _count = null, Int32? _tournamentId = null)
            {
                var t = PostCodesAsync(platform, _tournamentcodeparameters, _count, _tournamentId);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<List<System.String>> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<List<System.String>>> PostCodesAsync(PhysicalRegion platform, RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeParameters _tournamentcodeparameters, Int32? _count = null, Int32? _tournamentId = null)
            {
                RiotGamesApi.Interfaces.IResult<List<System.String>> rit = await new ApiCall()
                    .SelectApi<List<System.String>>(LolApiName.Tournament, 3)
                    .For(LolApiMethodName.Codes)
                    .AddParameter()
                    .Build(platform)
                    .PostAsync(_tournamentcodeparameters,
                        new QueryParameter("count", _count),
                        new QueryParameter("tournamentId", _tournamentId)
                    ).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<Int32> PutCodesOnlyTournamentCode(PhysicalRegion platform, String _OnlyTournamentCode, RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeUpdateParameters _tournamentcodeupdateparameters = null)
            {
                var t = PutCodesOnlyTournamentCodeAsync(platform, _OnlyTournamentCode, _tournamentcodeupdateparameters);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<Int32> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<Int32>> PutCodesOnlyTournamentCodeAsync(PhysicalRegion platform, String _OnlyTournamentCode, RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeUpdateParameters _tournamentcodeupdateparameters = null)
            {
                RiotGamesApi.Interfaces.IResult<Int32> rit = await new ApiCall()
                    .SelectApi<Int32>(LolApiName.Tournament, 3)
                    .For(LolApiMethodName.Codes)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyTournamentCode, _OnlyTournamentCode))
                    .Build(platform)
                    .PutAsync(_tournamentcodeupdateparameters).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeDTO> GetCodesOnlyTournamentCode(PhysicalRegion platform, String _OnlyTournamentCode)
            {
                var t = GetCodesOnlyTournamentCodeAsync(platform, _OnlyTournamentCode);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeDTO> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeDTO>> GetCodesOnlyTournamentCodeAsync(PhysicalRegion platform, String _OnlyTournamentCode)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeDTO> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.TournamentEndPoints.TournamentCodeDTO>(LolApiName.Tournament, 3)
                    .For(LolApiMethodName.Codes)
                    .AddParameter(new ApiParameter(LolApiPath.OnlyTournamentCode, _OnlyTournamentCode))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.LobbyEventDTOWrapper> GetLobbyEventsByCode(PhysicalRegion platform, String _ByCode)
            {
                var t = GetLobbyEventsByCodeAsync(platform, _ByCode);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.LobbyEventDTOWrapper> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.LobbyEventDTOWrapper>> GetLobbyEventsByCodeAsync(PhysicalRegion platform, String _ByCode)
            {
                RiotGamesApi.Interfaces.IResult<RiotGamesApi.Library.v3.TournamentEndPoints.LobbyEventDTOWrapper> rit = await new ApiCall()
                    .SelectApi<RiotGamesApi.Library.v3.TournamentEndPoints.LobbyEventDTOWrapper>(LolApiName.Tournament, 3)
                    .For(LolApiMethodName.LobbyEvents)
                    .AddParameter(new ApiParameter(LolApiPath.ByCode, _ByCode))
                    .Build(platform)
                    .GetAsync().ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<Int32> PostProviders(PhysicalRegion platform, RiotGamesApi.Library.v3.TournamentEndPoints.ProviderRegistrationParameters _providerregistrationparameters)
            {
                var t = PostProvidersAsync(platform, _providerregistrationparameters);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<Int32> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<Int32>> PostProvidersAsync(PhysicalRegion platform, RiotGamesApi.Library.v3.TournamentEndPoints.ProviderRegistrationParameters _providerregistrationparameters)
            {
                RiotGamesApi.Interfaces.IResult<Int32> rit = await new ApiCall()
                    .SelectApi<Int32>(LolApiName.Tournament, 3)
                    .For(LolApiMethodName.Providers)
                    .AddParameter()
                    .Build(platform)
                    .PostAsync(_providerregistrationparameters).ConfigureAwait(false);
                return rit;
            }

            public RiotGamesApi.Interfaces.IResult<Int32> PostTournaments(PhysicalRegion platform, RiotGamesApi.Library.v3.TournamentEndPoints.TournamentRegistrationParameters _tournamentregistrationparameters)
            {
                var t = PostTournamentsAsync(platform, _tournamentregistrationparameters);
                t.Wait();
                RiotGamesApi.Interfaces.IResult<Int32> rit = t.Result;
                return rit;
            }

            public async Task<RiotGamesApi.Interfaces.IResult<Int32>> PostTournamentsAsync(PhysicalRegion platform, RiotGamesApi.Library.v3.TournamentEndPoints.TournamentRegistrationParameters _tournamentregistrationparameters)
            {
                RiotGamesApi.Interfaces.IResult<Int32> rit = await new ApiCall()
                    .SelectApi<Int32>(LolApiName.Tournament, 3)
                    .For(LolApiMethodName.Tournaments)
                    .AddParameter()
                    .Build(platform)
                    .PostAsync(_tournamentregistrationparameters).ConfigureAwait(false);
                return rit;
            }
        }
    }

    //
}