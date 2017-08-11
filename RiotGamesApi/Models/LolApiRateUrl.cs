using RiotGamesApi.Enums;
using RiotGamesApi.RateLimit;

namespace RiotGamesApi.Models
{
    public class LolApiRateUrl
    {
        public LolApiRateUrl SelectPaths(params LolApiMethodName[] paths)
        {
            return this;
        }

        public void SetLimit(params ApiLimit[] limits)
        {
        }
    }
}