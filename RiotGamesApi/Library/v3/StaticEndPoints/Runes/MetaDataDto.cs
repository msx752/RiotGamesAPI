using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.StaticEndPoints.Runes
{
    public class MetaDataDto
    {
        //
        [JsonProperty("tier")]
        public string tier { get; set; }

        //
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("isRune")]
        public bool isRune { get; set; }
    }
}