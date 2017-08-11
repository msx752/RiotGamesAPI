using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Items
{
    public class ItemDto
    {
        //
        [JsonProperty("gold")]
        public GoldDto gold { get; set; }

        //
        [JsonProperty("plaintext")]
        public string plaintext { get; set; }

        //
        [JsonProperty("hideFromAll")]
        public bool hideFromAll { get; set; }

        //
        [JsonProperty("inStore")]
        public bool inStore { get; set; }

        //
        [JsonProperty("into")]
        public List<string> into { get; set; }

        //
        [JsonProperty("id")]
        public int id { get; set; }

        //
        [JsonProperty("stats")]
        public InventoryDataStatsDto stats { get; set; }

        //
        [JsonProperty("colloq")]
        public string colloq { get; set; }

        //
        [JsonProperty("maps")]
        public Dictionary<string, bool> maps { get; set; }

        //
        [JsonProperty("specialRecipe")]
        public int specialRecipe { get; set; }

        //
        [JsonProperty("image")]
        public ImageDto image { get; set; }

        //
        [JsonProperty("description")]
        public string description { get; set; }

        //
        [JsonProperty("tags")]
        public List<string> tags { get; set; }

        //
        [JsonProperty("effect")]
        public Dictionary<string, string> effect { get; set; }

        //
        [JsonProperty("requiredChampion")]
        public string requiredChampion { get; set; }

        //
        [JsonProperty("from")]
        public List<string> from { get; set; }

        //
        [JsonProperty("group")]
        public string group { get; set; }

        //
        [JsonProperty("consumeOnFull")]
        public bool consumeOnFull { get; set; }

        //
        [JsonProperty("name")]
        public string name { get; set; }

        //
        [JsonProperty("consumed")]
        public bool consumed { get; set; }

        //
        [JsonProperty("sanitizedDescription")]
        public string sanitizedDescription { get; set; }

        //
        [JsonProperty("depth")]
        public int depth { get; set; }

        [JsonProperty("stacks")]
        public int stacks { get; set; }
    }
}