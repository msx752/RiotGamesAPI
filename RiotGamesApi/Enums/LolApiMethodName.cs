using RiotGamesApi.Attributes;

namespace RiotGamesApi.Enums
{
    /// <summary>
    /// name of Api method 
    /// </summary>
    public enum LolApiMethodName
    {
        [StringValue("champion-masteries")]
        ChampionMasteries,

        //[StringValue("scores")]
        Scores,

        //[StringValue("summoners")]
        Summoners,

        Champions,

        //[StringValue("challengerleagues")]
        ChallengerLeagues,

        //[StringValue("leagues")]
        Leagues,

        //[StringValue("masterleagues")]
        MasterLeagues,

        //[StringValue("positions")]
        Positions,

        //[StringValue("masteries")]
        Masteries,

        //[StringValue("matches")]
        Matches,

        //[StringValue("matchlists")]
        MatchLists,

        //[StringValue("timelines")]
        Timelines,

        //[StringValue("runes")]
        Runes,

        [StringValue("active-games")]
        ActiveGames,

        [StringValue("featured-games")]
        FeaturedGames,

        [StringValue("items")]
        Items,

        [StringValue("language-strings")]
        LanguageStrings,

        Languages,

        Maps,

        [StringValue("profile-icons")]
        ProfileIcons,

        Realms,

        [StringValue("summoner-spells")]
        SummonerSpells,

        Versions,

        Codes,

        [StringValue("lobby-events")]
        LobbyEvents,

        [StringValue("shard-data")]
        ShardData,

        /// <summary>
        /// Providers will need to call this endpoint first to register their callback URL and their
        /// API key with the tournament system before any other tournament provider endpoints will work.
        /// </summary>
        Providers,

        Tournaments,
    }
}