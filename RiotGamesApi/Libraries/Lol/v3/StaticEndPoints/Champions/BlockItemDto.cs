using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Champions
{
    public class BlockItemDto
    {
        //
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }
    }
}