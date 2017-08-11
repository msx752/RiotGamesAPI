using RiotGamesApi.Interfaces;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Models;

namespace RiotGamesApi.Libraries.Lol.Models
{
    public class LolApiRate : IApiRate
    {
        public LolApiRateUrl For(LolApiName api)
        {
            LolApiRateUrl url = new LolApiRateUrl();

            return url;
        }
    }
}