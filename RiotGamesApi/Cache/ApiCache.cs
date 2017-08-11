using Microsoft.Extensions.Caching.Memory;
using RiotGamesApi.Enums;
using RiotGamesApi.Interfaces;
using RiotGamesApi.Libraries.Lol.Enums;

namespace RiotGamesApi.Cache
{
    public class ApiCache : IApiCache
    {
        private CacheOption _cacheOption;
        private IMemoryCache _memoryCache;

        public CacheOption CacheOption
        {
            get => (_cacheOption ?? ApiSettings.ApiOptions.CacheOptions);
            set => _cacheOption = value;
        }

        internal IMemoryCache MemoryCache
        {
            get => (_memoryCache ?? ApiSettings.MemoryCache);
            set => _memoryCache = value;
        }

        void IApiCache.Add<T>(IProperty<T> data)
        {
            ((IApiCache)this).Remove<T>(data);
            var cacheEntryOptions = new MemoryCacheEntryOptions();
            if (data.UrlType == LolUrlType.Static)
            {
                cacheEntryOptions.SlidingExpiration = CacheOption.StaticApiCacheExpiry;
            }
            else
            {
                var selectRule = CacheOption.FindCacheRule(data.UrlType, data.ApiList.ApiName);
                cacheEntryOptions.SlidingExpiration = selectRule.ExpiryTime;
                // throw new RiotGamesApiException("cache works with static api for now!");
            }
            MemoryCache.Set(data.CacheKey, data.RiotResult.Result, cacheEntryOptions);
        }

        bool IApiCache.Get<T>(IProperty<T> data, out T cachedData)
        {
            return MemoryCache.TryGetValue<T>(data.CacheKey, out cachedData);
        }

        void IApiCache.Remove<T>(IProperty<T> data)
        {
            MemoryCache.Remove(data.CacheKey);
        }
    }
}