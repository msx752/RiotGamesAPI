using System.Collections.Concurrent;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.RateLimit.Property;

namespace RiotGamesApi.RateLimit
{
    public class RateLimitOption
    {
        public RateLimitOption()
        {
            DisableLimiting = false;
        }

        /// <summary>
        /// rate-limits which defined from userSettings 
        /// </summary>
        public ConcurrentDictionary<LolUrlType, RLolApiName> All { get; internal set; }

        /// <summary>
        /// disable rate-limiter (default: false) 
        /// </summary>
        public bool DisableLimiting { get; internal set; }

        private ConcurrentDictionary<string, ApiLimit> SpecialLeaguesLimits { get; set; } =
            new ConcurrentDictionary<string, ApiLimit>();

        public void SetLeagueApiLimit(ConcurrentDictionary<string, ApiLimit> val)
        {
            SpecialLeaguesLimits = val;
        }

        public ApiLimit FindLeagueApiLimit(string platform)
        {
            if (SpecialLeaguesLimits.ContainsKey(platform))
            {
                return SpecialLeaguesLimits[platform];
            }
            else
            {
                return null;
            }
        }
    }
}