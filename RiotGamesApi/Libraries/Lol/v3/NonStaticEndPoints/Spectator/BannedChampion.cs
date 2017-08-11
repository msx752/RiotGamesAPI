using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Spectator
{
    public class BannedChampion
    {
        //The turn during which the champion was banned
        [JsonProperty("pickTurn")]
        public int pickTurn { get; set; }

        //The ID of the banned champion
        [JsonProperty("championId")]
        public long championId { get; set; }

        //The ID of the team that banned the champion
        [JsonProperty("teamId")]
        public long teamId { get; set; }
    }
}