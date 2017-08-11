using RiotGamesApi.Interfaces;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.RateLimit;

namespace RiotGamesApi.Libraries.Lol.Models
{
    public class LolApiRateUrl : IApiRateUrl
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