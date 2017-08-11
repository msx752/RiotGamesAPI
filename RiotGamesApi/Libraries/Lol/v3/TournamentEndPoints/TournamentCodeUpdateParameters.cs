using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.Libraries.Lol.v3.TournamentEndPoints
{
    public class TournamentCodeUpdateParameters
    {
        //The spectator type (Legal values: NONE, LOBBYONLY, ALL)
        [JsonProperty("spectatorType")]
        public string spectatorType { get; set; }

        //The pick type (Legal values: BLIND_PICK, DRAFT_MODE, ALL_RANDOM, TOURNAMENT_DRAFT)
        [JsonProperty("pickType")]
        public string pickType { get; set; }

        //Comma separated list of summoner Ids
        [JsonProperty("allowedParticipants")]
        public string allowedParticipants { get; set; }

        //The map type (Legal values: SUMMONERS_RIFT, TWISTED_TREELINE, HOWLING_ABYSS)
        [JsonProperty("mapType")]
        public string mapType { get; set; }
    }
}