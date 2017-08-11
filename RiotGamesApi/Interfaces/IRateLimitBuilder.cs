using System.Collections.Concurrent;
using System.Collections.Generic;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.RateLimit;

using RiotGamesApi.RateLimit.Builder;
using RiotGamesApi.RateLimit.Property;


namespace RiotGamesApi.Interfaces
{
    public interface IRateLimitBuilder



    {
        ConcurrentDictionary<LolUrlType, RLolApiName> Limits { get; }


        RateLimitBuilder AddRateLimitFor(LolUrlType type, List<LolApiName> names, List<ApiLimit> limits, params LolApiMethodName[] methods);
        RateLimitBuilder AddRateLimitFor(LolUrlType type, LolApiName name, List<ApiLimit> limits, params LolApiMethodName[] methods);

        ConcurrentDictionary<LolUrlType, RLolApiName> Build();
    }
}