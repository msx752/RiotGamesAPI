using System;
using System.Collections.Generic;
using System.Linq;
using Force.DeepCloner;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;

namespace RiotGamesApi.RateLimit.Property
{
    public class RLolApiMethodName
    {
        private List<LolApiMethodName> _apiNames;
        private object _lock = new object();
        private DateTime _reTryAfter;
        private List<ApiLimit> _limits;
        private RateLimitType? _usedRateLimitType;
        private List<LolApiName> _names;

        public List<LolApiName> Names

        {
            get
            {
                lock (_lock)
                    return _names;
            }
            set
            {
                lock (_lock)
                    _names = value;
            }
        }

        public RLolApiMethodName(List<LolApiName> names, List<LolApiMethodName> methods, params ApiLimit[] limits) : this()
        {
            AddLimit(limits);
            Names.AddRange(names.Distinct());
            ApiMethods = methods;
        }

        public RLolApiMethodName(LolApiName name, List<LolApiMethodName> methods, params ApiLimit[] limits)
            : this(new List<LolApiName>() { name }, methods, limits)
        {
        }

        public RLolApiMethodName()
        {
            Limits = new List<ApiLimit>();
            ApiMethods = new List<LolApiMethodName>();
            Names = new List<LolApiName>();
        }

        public List<LolApiMethodName> ApiMethods
        {
            get
            {
                lock (_lock)
                {
                    return _apiNames;
                }
            }
            set
            {
                lock (_lock)
                {
                    _apiNames = value;
                }
            }
        }

        public RateLimitType? UsedRateLimitType
        {
            get
            {
                var isActive = IsRetryActive.DeepClone();
                lock (_lock)
                {
                    if (!isActive)
                        _usedRateLimitType = null;
                    return _usedRateLimitType;
                }
            }
            set
            {
                lock (_lock)
                    _usedRateLimitType = value;
            }
        }

        public bool IsRetryActive
        {
            get
            {
                return RetryAfter > DateTime.Now;
            }
        }

        public List<ApiLimit> Limits
        {
            get
            {
                lock (_lock)
                    return _limits;
            }
            private set
            {
                lock (_lock)
                    _limits = value;
            }
        }

        public DateTime RetryAfter
        {
            get
            {
                lock (_lock)
                {
                    return _reTryAfter;
                }
            }
            set
            {
                lock (_lock)
                {
                    _reTryAfter = value;
                }
            }
        }

        public void Add(List<LolApiName> names, params LolApiMethodName[] val)
        {
            if (names.Count == 0)
                throw new Exception("you have to specify the LolApiName For rate-limiting");

            if (val != null)
                ApiMethods.AddRange(val);

            Names.AddRange(names);
        }

        public void Add(LolApiName name, params LolApiMethodName[] val)
        {
            Add(new List<LolApiName>() { name }, val);
        }

        public void AddLimit(params ApiLimit[] limit)
        {
            if (limit == null || !limit.Any()) return;
            Limits.AddRange(limit);
            Limits = Limits.OrderByDescending<ApiLimit, TimeSpan>(p => p.Time).ToList();
        }

        public bool ContainsApiName(LolApiName name, LolApiMethodName method)
        {
            bool q1 = ApiMethods.Contains(method);
            bool q2 = Names.Contains(name);
            return q1 && q2;
        }
    }
}