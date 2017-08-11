using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.Library.v3.TournamentEndPoints
{
    public class TournamentCodeParameters
    {
        //The spectator type of the game. (Legal values: NONE, LOBBYONLY, ALL)
        [JsonProperty("spectatorType")]
        public string spectatorType { get; set; }

        //The team size of the game. Valid values are 1-5.
        [JsonProperty("teamSize")]
        public int teamSize { get; set; }

        //The pick type of the game. (Legal values: BLIND_PICK, DRAFT_MODE, ALL_RANDOM, TOURNAMENT_DRAFT)
        [JsonProperty("pickType")]
        public string pickType { get; set; }

        //Optional list of participants in order to validate the players eligible to join the lobby. NOTE: We currently do not enforce participants at the team level, but rather the aggregate of teamOne and teamTwo. We may add the ability to enforce at the team level in the future.
        [JsonProperty("allowedSummonerIds")]
        public SummonerIdParams allowedSummonerIds { get; set; }

        //The map type of the game. (Legal values: SUMMONERS_RIFT, TWISTED_TREELINE, HOWLING_ABYSS)
        [JsonProperty("mapType")]
        public string mapType { get; set; }

        //Optional string that may contain any data in any format, if specified at all. Used to denote any custom information about the game.
        [JsonProperty("metadata")]
        public string metadata { get; set; }
    }
}