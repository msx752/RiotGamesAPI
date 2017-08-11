using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Items
{
    public class GroupDto
    {
        //
        [JsonProperty("MaxGroupOwnable")]
        public string MaxGroupOwnable { get; set; }

        [JsonProperty("key")]
        public string key { get; set; }
    }
}