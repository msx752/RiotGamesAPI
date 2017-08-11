using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Interfaces;
using RiotGamesApi.RateLimit;
using Microsoft.Extensions.Caching.Memory;

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
                return (IApiCache)ServiceProvider.GetService(typeof(IApiCache));
            }
        }

        /// <summary>
        /// RiotGamesApi all Options 
        /// </summary>
        public static IApiOption ApiOptions
        {
            get
            {
                return (IApiOption)ServiceProvider.GetService(typeof(IApiOption));
            }
        }

        /// <summary>
        /// RiotGamesApi Rate-Limiter 
        /// </summary>
        public static ApiRate ApiRate
        {
            get
            {
                return (ApiRate)ServiceProvider.GetService(typeof(ApiRate));
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

        /// <summary>
        /// .net core controller of memory caching 
        /// </summary>
        internal static IMemoryCache MemoryCache
        {
            get
            {
                return (IMemoryCache)ServiceProvider.GetService(typeof(IMemoryCache));
            }
        }
    }
}