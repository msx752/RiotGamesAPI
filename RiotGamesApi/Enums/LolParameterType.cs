using RiotGamesApi.Attributes;
using RiotGamesApi.Library.Enums;
using RiotGamesApi.Library.Enums.GameConstants;

// ReSharper disable InconsistentNaming

namespace RiotGamesApi.Enums
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