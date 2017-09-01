using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using RiotGamesApi.Enums;
using RiotGamesApi.Interfaces;
using RiotGamesApi.Libraries.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.RateLimit.Property;

namespace RiotGamesApi.RateLimit.Builder
{
    public class RateLimitBuilder : IRateLimitBuilder
    {
        public RateLimitBuilder()
        {
            Limits = new ConcurrentDictionary<LolUrlType, RLolApiName>();
        }

        public ConcurrentDictionary<LolUrlType, RLolApiName> Limits { get; private set; }

        public RateLimitBuilder AddRateLimitFor(LolUrlType type, LolApiName name, List<ApiLimit> limits, params LolApiMethodName[] methods)
        {
            return AddRateLimitFor(type, new List<LolApiName>() { name }, limits, methods);
        }

        public RateLimitBuilder AddRateLimitFor(LolUrlType type, List<LolApiName> names, List<ApiLimit> limits, params LolApiMethodName[] methods)
        {
            var rla = new RLolApiName();
            var rlan = new RLolApiMethodName();
            rlan.Add(names, methods.Distinct().ToArray());
            rlan.AddLimit(limits.ToArray());
            rla.Add(rlan);
            if (!Limits.ContainsKey(type))
            {
                Limits.TryAdd(type, rla);
            }
            else
            {
                Limits[type].Add(rlan);
            }
            return this;
        }

        public ConcurrentDictionary<LolUrlType, RLolApiName> Build()
        {
            return Limits;
        }

        //SPECIAL LEAGUES V3 API RATE-LIMITING
        internal ConcurrentDictionary<string, ApiLimit> Special_Leagues_Limits { get; } =
            new ConcurrentDictionary<string, ApiLimit>();

        /// <summary>
        /// method-rate limit example for EUW: 300 requests / 1 minute 
        /// </summary>
        /// <param name="EUW1">
        /// </param>
        /// <param name="NA1">
        /// </param>
        /// <param name="EUN1">
        /// </param>
        /// <param name="BR1">
        /// </param>
        /// <param name="KR">
        /// </param>
        /// <param name="LA1">
        /// </param>
        /// <param name="LA2">
        /// </param>
        /// <param name="TR1">
        /// </param>
        /// <param name="OC1">
        /// </param>
        /// <param name="JP1">
        /// </param>
        /// <param name="RU">
        /// </param>
        public void LeaguesApiLimitsInMinute(
            int EUW1 = 300,
            int NA1 = 270,
            int EUN1 = 165,
            int BR1 = 90,
            int KR = 90,
            int LA1 = 80,
            int LA2 = 80,
            int TR1 = 60,
            int OC1 = 55,
            int JP1 = 35,
            int RU = 35)
        {
            Special_Leagues_Limits.Clear();
            Special_Leagues_Limits[ServicePlatform.EUW1.ToString()] = new ApiLimit(new System.TimeSpan(0, 1, 0), EUW1, RateLimitType.MethodRate);
            Special_Leagues_Limits[ServicePlatform.NA1.ToString()] = new ApiLimit(new System.TimeSpan(0, 1, 0), NA1, RateLimitType.MethodRate);
            Special_Leagues_Limits[ServicePlatform.EUN1.ToString()] = new ApiLimit(new System.TimeSpan(0, 1, 0), EUN1, RateLimitType.MethodRate);
            Special_Leagues_Limits[ServicePlatform.BR1.ToString()] = new ApiLimit(new System.TimeSpan(0, 1, 0), BR1, RateLimitType.MethodRate);
            Special_Leagues_Limits[ServicePlatform.KR.ToString()] = new ApiLimit(new System.TimeSpan(0, 1, 0), KR, RateLimitType.MethodRate);
            Special_Leagues_Limits[ServicePlatform.LA1.ToString()] = new ApiLimit(new System.TimeSpan(0, 1, 0), LA1, RateLimitType.MethodRate);
            Special_Leagues_Limits[ServicePlatform.LA2.ToString()] = new ApiLimit(new System.TimeSpan(0, 1, 0), LA2, RateLimitType.MethodRate);
            Special_Leagues_Limits[ServicePlatform.TR1.ToString()] = new ApiLimit(new System.TimeSpan(0, 1, 0), TR1, RateLimitType.MethodRate);
            Special_Leagues_Limits[ServicePlatform.OC1.ToString()] = new ApiLimit(new System.TimeSpan(0, 1, 0), OC1, RateLimitType.MethodRate);
            Special_Leagues_Limits[ServicePlatform.JP1.ToString()] = new ApiLimit(new System.TimeSpan(0, 1, 0), JP1, RateLimitType.MethodRate);
            Special_Leagues_Limits[ServicePlatform.RU.ToString()] = new ApiLimit(new System.TimeSpan(0, 1, 0), RU, RateLimitType.MethodRate);
        }

        ///
    }
}