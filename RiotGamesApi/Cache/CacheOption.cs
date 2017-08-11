using System;
using System.Collections.Generic;
using System.Linq;
using RiotGamesApi.Enums;

namespace RiotGamesApi.Cache
{
    /// <summary>
    /// default of ApiCaching is disabled 
    /// </summary>
    public class CacheOption
    {
        private readonly object _lock2 = new object();
        private List<CustomCacheRule> _customCacheRules = new List<CustomCacheRule>();

        /// <summary>
        /// default value: false 
        /// </summary>
        public bool EnableStaticApiCaching
        {
            get
            {
                lock (_lock2)
                    return _enableStaticApiCaching;
            }
            set
            {
                lock (_lock2)
                    _enableStaticApiCaching = value;
            }
        }

        /// <summary>
        /// custom api rules for type of non-static api (default value: false) 
        /// </summary>
        public bool EnableCustomApiCaching
        {
            get
            {
                lock (_lock)
                    return _enableCustomApiCaching;
            }
            set
            {
                lock (_lock)
                    _enableCustomApiCaching = value;
            }
        }

        private object _lock = new object();
        private bool _enableCustomApiCaching = false;
        private bool _enableStaticApiCaching = false;
        private TimeSpan _staticApiCacheExpiry = new TimeSpan(0, 30, 0);

        private List<CustomCacheRule> CustomCacheRules
        {
            get
            {
                lock (_lock)
                    return _customCacheRules;
            }
            set
            {
                lock (_lock)
                    _customCacheRules = value;
            }
        }

        /// <summary>
        /// add cache rule for non-static api 
        /// </summary>
        /// <param name="urlType">
        /// api url type 
        /// </param>
        /// <param name="apiName">
        /// api method name 
        /// </param>
        /// <param name="expiryTime">
        /// expiry time (max-limit: 1 hour) 
        /// </param>
        public void AddCacheRule(LolUrlType urlType, LolApiName apiName, TimeSpan expiryTime)
        {
            if (urlType != LolUrlType.Static)
            {
                if (expiryTime.Hours >= 1)
                    expiryTime = new TimeSpan(1, 0, 0);

                var found = FindCacheRule(urlType, apiName);
                if (found != null)
                    CustomCacheRules.Remove(found);
                CustomCacheRules.Add(new CustomCacheRule(urlType, apiName, expiryTime));
            }
        }

        /// <summary>
        /// removs cache rule 
        /// </summary>
        /// <param name="urlType">
        /// </param>
        /// <param name="apiName">
        /// </param>
        public void RemoveCacheRule(LolUrlType urlType, LolApiName apiName)
        {
            CustomCacheRules.RemoveAll(p => p.UrlType == urlType && p.ApiName == apiName);
        }

        /// <summary>
        /// clears all cache rules 
        /// </summary>
        public void ClearCacheRules()
        {
            CustomCacheRules.Clear();
        }

        /// <summary>
        /// finds exists cache rules 
        /// </summary>
        /// <param name="urlType">
        /// </param>
        /// <param name="apiName">
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="predicate" /> is null. 
        /// </exception>
        public CustomCacheRule FindCacheRule(LolUrlType urlType, LolApiName apiName)
        {
            var found = CustomCacheRules.FirstOrDefault(p => p.UrlType == urlType && p.ApiName == apiName);
            return found;
        }

        /// <summary>
        /// default expiry time: 30min 
        /// </summary>
        public TimeSpan StaticApiCacheExpiry
        {
            get
            {
                lock (_lock2)
                    return _staticApiCacheExpiry;
            }
            set
            {
                lock (_lock2)
                    _staticApiCacheExpiry = value;
            }
        }
    }
}