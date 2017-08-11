using System.Collections.Concurrent;
using RiotGamesApi.Enums;

namespace RiotGamesApi.RateLimit.Property
{
    public class RUrlType
    {
        private object _lock = new object();
        private ConcurrentDictionary<LolUrlType, RLolApiName> _urlTypes = new ConcurrentDictionary<LolUrlType, RLolApiName>();

        public ConcurrentDictionary<LolUrlType, RLolApiName> UrlTypes
        {
            get
            {
                lock (_lock)
                {
                    return _urlTypes;
                }
            }
            set
            {
                lock (_lock)
                {
                    _urlTypes = value;
                }
            }
        }

        public void Add(LolUrlType val, RLolApiMethodName rlan)
        {
            UrlTypes.TryAdd(val, new RLolApiName(rlan));
        }

        public void Add(LolUrlType val, RLolApiName rlan)
        {
            UrlTypes.TryAdd(val, rlan);
        }

        public bool ContainsUrlTypes(LolUrlType name)
        {
            return UrlTypes.ContainsKey(name);
        }

        public RLolApiName Find(LolUrlType type)
        {
            if (ContainsUrlTypes(type))
            {
                return UrlTypes[type];
            }
            else
            {
                return null;
            }
        }
    }
}