using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Maps
{
    public class MapDataDto
    {
        //
        [JsonProperty("data")]
        public Dictionary<string, MapDetailsDto> data { get; set; }

        //
        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }
}