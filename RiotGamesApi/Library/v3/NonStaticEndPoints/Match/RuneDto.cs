using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.Match
{
    public class RuneDto
    {
        //
        [JsonProperty("runeId")]
        public int runeId { get; set; }

        //
        [JsonProperty("rank")]
        public int rank { get; set; }
    }
}