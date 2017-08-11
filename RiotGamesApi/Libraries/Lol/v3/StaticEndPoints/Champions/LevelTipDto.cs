using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Champions
{
    public class LevelTipDto
    {
        //
        [JsonProperty("effect")]
        public List<string> effect { get; set; }

        [JsonProperty("label")]
        public List<string> label { get; set; }
    }
}