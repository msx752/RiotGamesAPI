using System;
using System.Collections.Generic;
using RiotGamesApi.Enums;

namespace RiotGamesApi.RateLimit
{
    public class RateLimitData
    {
        /// <summary>
        /// disabling rate-limiter (default: false) 
        /// </summary>
        public bool DisableLimiting { get; set; } = false;

        private ApiLimit MatchListXMethodRateLimit { get; set; }

        private List<ApiLimit> XAppRateLimit { get; } = new List<ApiLimit>();

        private List<ApiLimit> XMethodRateLimit { get; } = new List<ApiLimit>();

        /// <summary>
        /// DEVELOPMENT RATE LIMITS 
        /// </summary>
        /// <param name="limits">
        /// </param>
        /// <param name="removeDefaultValues">
        /// calls ClearXAppRateLimits(); 
        /// </param>
        public void AddXAppRateLimits(Dictionary<TimeSpan, int> limits, bool removeDefaultValues = true)
        {
            if (removeDefaultValues)
                ClearXAppRateLimits();

            foreach (var li in limits)
            {
                XAppRateLimit.Add(new ApiLimit(li.Key, li.Value, RateLimitType.AppRate));
            }
        }

        /// <summary>
        /// removes default values 
        /// </summary>
        public void ClearXAppRateLimits()
        {
            XAppRateLimit.Clear();
        }

        public List<ApiLimit> GetXAppRateLimit()
        {
            return XAppRateLimit;
        }
    }
}