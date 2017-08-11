using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.RateLimit.Property;

namespace RiotGamesApi.Interfaces
{
    public interface IApiRateLimit
    {
        MyRateLimit Rates { get; set; }

        void Add(string region, LolUrlType type, RLolApiName rla);

        RLolApiMethodName FindRate(RateLimitProperties prop);

        RLolApiMethodName FindRate(string platform, LolUrlType type, LolApiName apiName, LolApiMethodName method);

        void Handle(RateLimitProperties prop);

        void SetRetryTime(RateLimitProperties prop, RateLimitType limitType, int retryAfterSeconds);

        void SetRetryTime(string region, LolUrlType type, LolApiName name, RateLimitType limitType, LolApiMethodName method, int retryAfterSeconds);
    }
}