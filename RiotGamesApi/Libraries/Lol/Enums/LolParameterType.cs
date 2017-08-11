using RiotGamesApi.Attributes;
using RiotGamesApi.Libraries.Enums;
using RiotGamesApi.Libraries.Lol.Enums.GameConstants;

// ReSharper disable InconsistentNaming

namespace RiotGamesApi.Libraries.Lol.Enums
{
    /// <summary>
    /// url path parameter data 
    /// </summary>
    public enum LolParameterType
    {
        [ParameterType(typeof(ServicePlatform))]
        platformId,

        [ParameterType(typeof(long))]
        summonerId,

        [ParameterType(typeof(long))]
        championId,

        [ParameterType(typeof(long))]
        matchId,

        [ParameterType(typeof(long))]
        accountId,

        [ParameterType(typeof(long))]
        id,

        [ParameterType(typeof(MatchMakingQueue))]
        queue,

        [ParameterType(typeof(string))]
        tournamentCode,

        [ParameterType(typeof(string))]
        summonerName,
    }
}