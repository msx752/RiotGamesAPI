using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;

namespace RiotGamesApi.RateLimit.Property
{
    public class RateLimitProperties
    {
        public LolApiName ApiName { get; set; }
        public LolApiMethodName ApiMethod { get; set; }
        public string Platform { get; set; }
        public LolUrlType UrlType { get; set; }

        public override string ToString()
        {
            return $"{Platform}:{UrlType}:{ApiName}";
        }
    }
}