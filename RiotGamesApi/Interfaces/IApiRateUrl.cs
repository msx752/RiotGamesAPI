using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.Models;
using RiotGamesApi.Models;
using RiotGamesApi.RateLimit;

namespace RiotGamesApi.Interfaces
{
    public interface IApiRateUrl
    {
        LolApiRateUrl SelectPaths(params LolApiMethodName[] paths);

        void SetLimit(params ApiLimit[] limits);
    }
}