using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.StaticEndPoints.Runes
{
    public class RuneDto
    {
        //
        [JsonProperty("stats")]
        public RuneStatsDto stats { get; set; }

        //
        [JsonProperty("name")]
        public string name { get; set; }

        //
        [JsonProperty("tags")]
        public List<string> tags { get; set; }

        //
        [JsonProperty("image")]
        public ImageDto image { get; set; }

        //
        [JsonProperty("sanitizedDescription")]
        public string sanitizedDescription { get; set; }

        //
        [JsonProperty("rune")]
        public MetaDataDto rune { get; set; }

        //
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }
    }
}