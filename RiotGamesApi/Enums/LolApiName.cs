using RiotGamesApi.Attributes;

namespace RiotGamesApi.Enums
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
        //[StringValue("platform")]
        Platform,

        [UrlType(LolUrlType.NonStatic)]
        //[StringValue("league")]
        League,

        [UrlType(LolUrlType.NonStatic)]
        //[StringValue("match")]
        Match,

        [UrlType(LolUrlType.NonStatic)]
        //[StringValue("spectator")]
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