using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.StaticEndPoints.Masteries
{
    public class MasteryDto
    {
        //
        [JsonProperty("prereq")]
        public string prereq { get; set; }

        //(Legal values: Cunning, Ferocity, Resolve)
        [JsonProperty("masteryTree")]
        public string masteryTree { get; set; }

        //
        [JsonProperty("name")]
        public string name { get; set; }

        //
        [JsonProperty("ranks")]
        public int ranks { get; set; }

        //
        [JsonProperty("image")]
        public ImageDto image { get; set; }

        //
        [JsonProperty("sanitizedDescription")]
        public List<string> sanitizedDescription { get; set; }

        //
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("description")]
        public List<string> description { get; set; }
    }
}