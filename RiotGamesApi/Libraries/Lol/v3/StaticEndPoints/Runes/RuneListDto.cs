using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Runes
{
    public class RuneListDto
    {
        //
        [JsonProperty("data")]
        public Dictionary<string, RuneDto> data { get; set; }

        //
        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}