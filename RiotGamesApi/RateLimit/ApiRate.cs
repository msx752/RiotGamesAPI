using System;
using System.Diagnostics;
using System.Threading.Tasks;
using RiotGamesApi.Enums;
using RiotGamesApi.Models;
using RiotGamesApi.RateLimit.Property;
using Force.DeepCloner;

namespace RiotGamesApi.RateLimit
{
    /// <summary>
    /// RiotGamesApi special RateLimiter 
    /// </summary>
    public class ApiRate
    {
        private MyRateLimit _rates = new MyRateLimit();

        //private object _lock = new object();
        private readonly object _lock2 = new object();

        public MyRateLimit Rates
        {
            get
            {
                lock (_lock2)
                    return _rates;
            }
            set
            {
                lock (_lock2)
                    _rates = value;
            }
        }

        /// <summary>
        /// specify new rate-limit for api 
        /// </summary>
        /// <param name="region">
        /// </param>
        /// <param name="type">
        /// </param>
        /// <param name="rla">
        /// pre-defined when web-server starts 
        /// </param>
        public void Add(string region, LolUrlType type, RLolApiName rla)
        {
            Rates.Add(region, type, rla);
        }

        public RLolApiMethodName FindRate(RateLimitProperties prop)
        {
            return Rates.Find(prop.Platform, prop.UrlType, prop.ApiName, prop.ApiMethod);
        }

        public RLolApiMethodName FindRate(string platform, LolUrlType type, LolApiName apiName, LolApiMethodName method)
        {
            return Rates.Find(platform, type, apiName, method);
        }

        /// <summary>
        /// rate limit handler 
        /// </summary>
        /// <param name="prop">
        /// </param>
        public void Handle(RateLimitProperties prop)
        {
            if (ApiSettings.ApiOptions.RateLimitOptions.DisableLimiting == false)
            {
                //DateTime start = DateTime.Now;
                Wait(prop);
                //Debug.WriteLine($"{(DateTime.Now - start).Milliseconds} ms elapsed.");
            }
        }

        /// <summary>
        /// get data from Retry-After 
        /// </summary>
        /// <param name="prop">
        /// </param>
        /// <param name="limitType">
        /// </param>
        /// <param name="retryAfterSeconds">
        /// value of Retry-After 
        /// </param>
        public void SetRetryTime(RateLimitProperties prop, RateLimitType limitType, int retryAfterSeconds)
        {
            SetRetryTime(prop.Platform, prop.UrlType, prop.ApiName, limitType, prop.ApiMethod, retryAfterSeconds);
        }

        /// <summary>
        /// get data from Retry-After 
        /// </summary>
        /// <param name="prop">
        /// </param>
        /// <param name="name">
        /// </param>
        /// <param name="limitType">
        /// </param>
        /// <param name="retryAfterSeconds">
        /// value of Retry-After 
        /// </param>
        /// <param name="region">
        /// </param>
        /// <param name="type">
        /// </param>
        /// <exception cref="RiotGamesApiException">
        /// Condition. 
        /// </exception>
        public void SetRetryTime(string region, LolUrlType type, LolApiName name, RateLimitType limitType, LolApiMethodName method, int retryAfterSeconds)
        {
            var regionLimit = Rates.Find(region, type, name, method);
            if (regionLimit == null)
            {
                throw new RiotGamesApiException($"Undefined {limitType} limit type for region:{region},type:{type},name:{name}");
            }
            regionLimit.RetryAfter = DateTime.Now.AddSeconds(retryAfterSeconds);
            regionLimit.UsedRateLimitType = limitType;
        }

        /// <summary>
        /// rate-limit main function 
        /// </summary>
        /// <param name="prop">
        /// </param>
        private void Wait(RateLimitProperties prop)
        {
            TimeSpan currentDelay = TimeSpan.Zero;
            RLolApiMethodName regionLimit = Rates.Find(prop.Platform, prop.UrlType, prop.ApiName, prop.ApiMethod);
            if (regionLimit == null)
            {
                var snc = ApiSettings.ApiOptions.RateLimitOptions.All[prop.UrlType];
                Add(prop.Platform, prop.UrlType, snc.DeepClone());
                regionLimit = Rates.Find(prop.Platform, prop.UrlType, prop.ApiName, prop.ApiMethod);
            }
            //lock (_lock)
            {
                if (regionLimit.IsRetryActive)
                {
                    currentDelay = (regionLimit.RetryAfter - DateTime.Now);
                    Debug.WriteLine($"Limit Exceeded Retry-After:{currentDelay}, Region:{prop.Platform}, ApiType:{prop.UrlType}, ApiName:{prop.ApiName}, ApiMethod:{prop.ApiMethod} Forced-Limit:{regionLimit.UsedRateLimitType}");
                }
                foreach (var limit in regionLimit.Limits)
                {
                    if (limit.Counter < limit.Limit)
                        continue;

                    var largestDelay = limit.ChainStartTime.Add(limit.Time) - DateTime.Now;

                    Debug.WriteLine(
                        $"[{DateTime.Now:MM/dd/yyyy HH:mm:ss.fff}] limit:{limit.Limit}\tregion:{prop.Platform}\ttype:{prop.UrlType}\tapiName:{prop.ApiName}\tmultipler:{limit.Time}\tcount:{limit.Counter}\t\tDelay:{largestDelay}");

                    if (largestDelay > currentDelay)
                        currentDelay = largestDelay;

                    break;
                }
                regionLimit.Limits.ForEach((limit) =>
                {
                    if (limit.ChainStartTime <= DateTime.Now.Add(currentDelay) - limit.Time)
                        limit.Counter = 0;

                    limit.ChainStartTime = DateTime.Now.Add(currentDelay);
                    limit.Counter++;
                });
            }
            Task.Delay(currentDelay).Wait();
        }
    }
}