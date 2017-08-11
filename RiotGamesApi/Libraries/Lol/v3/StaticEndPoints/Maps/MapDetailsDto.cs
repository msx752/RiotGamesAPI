using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Maps
{
    public class MapDetailsDto
    {
        //
        [JsonProperty("mapName")]
        public string mapName { get; set; }

        //
        [JsonProperty("image")]
        public ImageDto image { get; set; }

        //
        [JsonProperty("mapId")]
        public long mapId { get; set; }

        [JsonProperty("unpurchasableItemList")]
        public List<long> unpurchasableItemList { get; set; }
    }
}