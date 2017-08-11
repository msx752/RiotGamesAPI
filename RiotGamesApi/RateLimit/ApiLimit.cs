using System;
using RiotGamesApi.Enums;

namespace RiotGamesApi.RateLimit
{
    /// <summary>
    /// specified rate limit 
    /// </summary>
    public class ApiLimit
    {
        //private object _lock = new object();
        private int _counter;

        private DateTime _chainStartTime;

        /// <summary>
        /// specified rate limit 
        /// </summary>
        /// <param name="ts">
        /// timer interval 
        /// </param>
        /// <param name="limit">
        /// max. limit 
        /// </param>
        /// <param name="limitType">
        /// RiotGames X-Rate-Limit-Type 
        /// </param>
        public ApiLimit(TimeSpan ts, int limit, RateLimitType limitType)
        {
            Limit = limit;
            Time = ts;
            LimitType = limitType;
        }

        /// <summary>
        /// request start time 
        /// </summary>
        public DateTime ChainStartTime
        {
            get
            {
                //lock (_lock)
                return _chainStartTime;
            }
            internal set
            {
                //lock (_lock)
                _chainStartTime = value;
            }
        }

        /// <summary>
        /// consumed limit 
        /// </summary>
        public int Counter
        {
            get
            {
                //lock (_lock)
                return _counter;
            }
            internal set
            {
                //lock (_lock)
                _counter = value;
            }
        }

        /// <summary>
        /// max. limit 
        /// </summary>
        public int Limit { get; private set; }

        /// <summary>
        /// RiotGames X-Rate-Limit-Type 
        /// </summary>
        public RateLimitType LimitType { get; private set; }

        /// <summary>
        /// time interval 
        /// </summary>
        public TimeSpan Time { get; private set; }

        public override string ToString()
        {
            return $"{Time}:{Limit}:{Counter}";
        }
    }
}