using RiotGamesApi.Attributes;
using RiotGamesApi.Enums;

namespace RiotGamesApi.Libraries.Lol.Enums
{
    /// <summary>
    /// url path name of api 
    /// </summary>
    public enum LolApiName
    {
        [UrlType(LolUrlType.NonStatic)]
        [StringValue("summoner")]
        Summoner,

        [UrlType(LolUrlType.NonStatic)]
        [StringValue("champion-mastery")]
        ChampionMastery,

        [UrlType(LolUrlType.NonStatic)]
        Platform,

        [UrlType(LolUrlType.NonStatic)]
        League,

        [UrlType(LolUrlType.NonStatic)]
        Match,

        [UrlType(LolUrlType.NonStatic)]
        Spectator,

        [UrlType(LolUrlType.Static)]
        [StringValue("static-data")]
        StaticData,

        [UrlType(LolUrlType.Status)]
        Status,

        [UrlType(LolUrlType.Tournament)]
        [StringValue("tournament-stub")]
        TournamentStub,

        [UrlType(LolUrlType.Tournament)]
        [StringValue("tournament")]
        Tournament,
    }
}