using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Items
{
    public class ItemListDto
    {
        //
        [JsonProperty("data")]
        public Dictionary<string, ItemDto> data { get; set; }

        //
        [JsonProperty("version")]
        public string version { get; set; }

        //
        [JsonProperty("tree")]
        public List<ItemTreeDto> tree { get; set; }

        //
        [JsonProperty("groups")]
        public List<GroupDto> groups { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }
}