using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.Match
{
    public class TeamBansDto
    {
        //
        [JsonProperty("pickTurn")]
        public int pickTurn { get; set; }

        [JsonProperty("championId")]
        public int championId { get; set; }
    }
}