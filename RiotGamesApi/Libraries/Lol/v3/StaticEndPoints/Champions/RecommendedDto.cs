using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Champions
{
    public class RecommendedDto
    {
        //
        [JsonProperty("map")]
        public string map { get; set; }

        //
        [JsonProperty("blocks")]
        public List<BlockDto> blocks { get; set; }

        //
        [JsonProperty("champion")]
        public string champion { get; set; }

        //
        [JsonProperty("title")]
        public string title { get; set; }

        //
        [JsonProperty("priority")]
        public bool priority { get; set; }

        //
        [JsonProperty("mode")]
        public string mode { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }
}