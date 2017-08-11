using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Cache;
using RiotGamesApi.Enums;
using RiotGamesApi.Interfaces;
using RiotGamesApi.RateLimit;

namespace RiotGamesApi.Models
{
    /// <summary>
    /// global RiotGamesApi Options 
    /// </summary>
    public class LolApiOptions : IApiOption
    {
        public LolApiOptions()
        {
            ((IApiOption)this).RiotGamesApis = new Dictionary<LolUrlType, RiotGamesApi>();
            RateLimitOptions = new RateLimitOption();
        }

        /// <summary>
        /// Rate-Limiting options 
        /// </summary>
        public RateLimitOption RateLimitOptions { get; internal set; }

        /// <summary>
        /// Api Caching options 
        /// </summary>
        public CacheOption CacheOptions { get; set; }

        string IApiOption.NonStaticUrl => $"{Url}/lol";
        public string RiotApiKey { get; set; }
        Dictionary<LolUrlType, RiotGamesApi> IApiOption.RiotGamesApis { get; set; }
        string IApiOption.StaticUrl => $"{((IApiOption)this).NonStaticUrl}";

        string IApiOption.TournamentUrl => $"{Url}/lol";
        string IApiOption.StatusUrl => $"{Url}/lol";

        /// <summary>
        /// main api request url 
        /// </summary>
        public string Url { get; set; } = "";

        //private string _staticUrl;
        //private string _nonStaticUrl;
    }
}