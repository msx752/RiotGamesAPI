using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Cache;
using RiotGamesApi.Enums;
using RiotGamesApi.RateLimit;

namespace RiotGamesApi.Interfaces
{
    public interface IApiOption
    { /// <summary>
      /// Rate-Limiting options </summary>
        RateLimitOption RateLimitOptions { get; }

        /// <summary>
        /// Api Caching options 
        /// </summary>
        CacheOption CacheOptions { get; set; }

        string NonStaticUrl { get; }
        string RiotApiKey { get; set; }
        Dictionary<LolUrlType, Models.RiotGamesApi> RiotGamesApis { get; set; }
        string StaticUrl { get; }
        string TournamentUrl { get; }
        string StatusUrl { get; }

        /// <summary>
        /// main api request url 
        /// </summary>
        string Url { get; set; }
    }
}