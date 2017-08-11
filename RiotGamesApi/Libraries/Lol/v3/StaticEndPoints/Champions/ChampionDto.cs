using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Champions
{
    public class ChampionDto
    {
        //
        [JsonProperty("info")]
        public InfoDto info { get; set; }

        //
        [JsonProperty("enemytips")]
        public List<string> enemytips { get; set; }

        //
        [JsonProperty("stats")]
        public StatsDto stats { get; set; }

        //
        [JsonProperty("name")]
        public string name { get; set; }

        //
        [JsonProperty("title")]
        public string title { get; set; }

        //
        [JsonProperty("image")]
        public ImageDto image { get; set; }

        //
        [JsonProperty("tags")]
        public List<string> tags { get; set; }

        //
        [JsonProperty("partype")]
        public string partype { get; set; }

        //
        [JsonProperty("skins")]
        public List<SkinDto> skins { get; set; }

        //
        [JsonProperty("passive")]
        public PassiveDto passive { get; set; }

        //
        [JsonProperty("recommended")]
        public List<RecommendedDto> recommended { get; set; }

        //
        [JsonProperty("allytips")]
        public List<string> allytips { get; set; }

        //
        [JsonProperty("key")]
        public string key { get; set; }

        //
        [JsonProperty("lore")]
        public string lore { get; set; }

        //
        [JsonProperty("id")]
        public int id { get; set; }

        //
        [JsonProperty("blurb")]
        public string blurb { get; set; }

        [JsonProperty("spells")]
        public List<ChampionSpellDto> spells { get; set; }
    }
}