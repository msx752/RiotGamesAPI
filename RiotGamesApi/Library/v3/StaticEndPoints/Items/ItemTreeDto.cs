using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.StaticEndPoints.Items
{
    public class ItemTreeDto
    {
        //
        [JsonProperty("header")]
        public string header { get; set; }

        [JsonProperty("tags")]
        public List<string> tags { get; set; }
    }
}