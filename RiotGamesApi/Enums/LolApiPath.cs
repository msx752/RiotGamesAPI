using RiotGamesApi.Attributes;

namespace RiotGamesApi.Enums
{
    /// <summary>
    /// attribute StringValue is a type of 'LolParameterType' enum (it should be defined) 
    /// </summary>
    public enum LolApiPath
    {
        [StringValue("{matchId}")]
        OnlyMatchId,

        [StringValue("{id}")]
        OnlyId,

        [StringValue("{summonerId}")]
        OnlySummonerId,

        [StringValue("by-summoner/{summonerId}")]
        BySummoner,

        [StringValue("by-champion/{championId}")]
        ByChampion,

        [StringValue("by-account/{accountId}")]
        ByAccount,

        [StringValue("by-account/{accountId}/recent")]
        ByAccountRecent,

        [StringValue("by-name/{summonerName}")]
        ByName,

        [StringValue("by-queue/{queue}")]
        ByQueue,

        [StringValue("by-tournament-code/{tournamentCode}/ids")]
        ByTournamentCodeIds,

        [StringValue("by-tournament-code/{tournamentCode}")]
        ByTournamentCode,

        [StringValue("{tournamentCode}")]
        OnlyTournamentCode,

        [StringValue("by-match/{matchId}")]
        ByMatch,

        [StringValue("by-code/{tournamentCode}")]
        ByCode
    }
}