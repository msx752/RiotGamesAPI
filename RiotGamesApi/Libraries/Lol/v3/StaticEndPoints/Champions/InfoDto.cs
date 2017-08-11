using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Champions
{
    public class InfoDto
    {
        //
        [JsonProperty("difficulty")]
        public int difficulty { get; set; }

        //
        [JsonProperty("attack")]
        public int attack { get; set; }

        //
        [JsonProperty("defense")]
        public int defense { get; set; }

        [JsonProperty("magic")]
        public int magic { get; set; }
    }
}