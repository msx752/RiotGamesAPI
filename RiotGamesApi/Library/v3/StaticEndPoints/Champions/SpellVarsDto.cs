using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.StaticEndPoints.Champions
{
    public class SpellVarsDto
    {
        //
        [JsonProperty("ranksWith")]
        public string ranksWith { get; set; }

        //
        [JsonProperty("dyn")]
        public string dyn { get; set; }

        //
        [JsonProperty("link")]
        public string link { get; set; }

        //
        [JsonProperty("coeff")]
        public List<double> coeff { get; set; }

        [JsonProperty("key")]
        public string key { get; set; }
    }
}