using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Champions
{
    public class SkinDto
    {
        //
        [JsonProperty("num")]
        public int num { get; set; }

        //
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }
    }
}