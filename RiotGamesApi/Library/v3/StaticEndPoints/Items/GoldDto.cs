using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.StaticEndPoints.Items
{
    public class GoldDto
    {
        //
        [JsonProperty("sell")]
        public int sell { get; set; }

        //
        [JsonProperty("total")]
        public int total { get; set; }

        //
        [JsonProperty("base")]
        public int Base { get; set; }

        [JsonProperty("purchasable")]
        public bool purchasable { get; set; }
    }
}