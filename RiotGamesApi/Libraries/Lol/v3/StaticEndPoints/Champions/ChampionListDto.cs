using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Champions
{
    public class ChampionListDto
    {
        //
        [JsonProperty("keys")]
        public Dictionary<string, string> keys { get; set; }

        //
        [JsonProperty("data")]
        public Dictionary<string, ChampionDto> data { get; set; }

        //
        [JsonProperty("version")]
        public string version { get; set; }

        //
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("format")]
        public string format { get; set; }
    }
}