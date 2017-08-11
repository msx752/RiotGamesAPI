using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Match
{
    public class MatchPositionDto
    {
        //
        [JsonProperty("y")]
        public int y { get; set; }

        [JsonProperty("x")]
        public int x { get; set; }
    }
}