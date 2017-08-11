using System.Collections.Generic;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.Models;
using RiotGamesApi.Models;

namespace RiotGamesApi.Interfaces
{
    public interface IRiotGamesApi
    {
        string ApiUrl { get; set; }
        List<LolApiUrl> RiotGamesApiUrls { get; }

        LolApiUrl AddApi(LolApiName suffix1, double version);
    }
}