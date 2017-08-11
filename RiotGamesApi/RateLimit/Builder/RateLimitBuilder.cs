using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using RiotGamesApi.Enums;
using RiotGamesApi.RateLimit.Property;

namespace RiotGamesApi.RateLimit.Builder
{
    public class RateLimitBuilder
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
    }
}