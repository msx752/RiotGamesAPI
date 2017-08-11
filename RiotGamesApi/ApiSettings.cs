using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Interfaces;
using RiotGamesApi.RateLimit;
using Microsoft.Extensions.Caching.Memory;
using RiotGamesApi.Libraries.Lol.Models;

namespace RiotGamesApi
{
    public static class ApiSettings
    {
        private static IServiceProvider _serviceProvider = null;

        /// <summary>
        /// ApiCache controller 
        /// </summary>
        public static IApiCache ApiCache
        {
            get
            {
                return GetService<IApiCache>();
            }
        }

        /// <summary>
        /// RiotGamesApi all Options 
        /// </summary>
        public static IApiOption ApiOptions
        {
            get
            {
                return GetService<IApiOption>();
            }
        }

        /// <summary>
        /// RiotGamesApi Rate-Limiter 
        /// </summary>
        public static LolApiRateLimit ApiRate
        {
            get
            {
                return GetService<LolApiRateLimit>();
            }
        }

        /// <summary>
        /// .net core dependency injection 
        /// </summary>
        public static IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
            set
            {
                if (_serviceProvider == null)
                    _serviceProvider = value;
            }
        }

        public static T GetService<T>()
        {
            return (T)ServiceProvider.GetService(typeof(T));
        }

        /// <summary>
        /// .net core controller of memory caching 
        /// </summary>
        internal static IMemoryCache MemoryCache
        {
            get
            {
                return GetService<IMemoryCache>();
            }
        }
    }
}