using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.Models;
using RiotGamesApi.Models;

namespace RiotGamesApi.Interfaces
{
    public interface IApiRate
    {
        LolApiRateUrl For(LolApiName api);
    }
}