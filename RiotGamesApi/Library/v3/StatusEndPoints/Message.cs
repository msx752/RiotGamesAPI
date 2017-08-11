using Newtonsoft.Json;
using RiotGamesApi.Library.v3.StatusEndPoints;
using System.Collections.Generic;

namespace RiotGamesApi.Library.v3.StatusEndPoints
{
    public class Message
    {
        //
        [JsonProperty("severity")]
        public string severity { get; set; }

        //
        [JsonProperty("author")]
        public string author { get; set; }

        //
        [JsonProperty("created_at")]
        public string created_at { get; set; }

        //
        [JsonProperty("translations")]
        public List<Translation> translations { get; set; }

        //
        [JsonProperty("updated_at")]
        public string updated_at { get; set; }

        //
        [JsonProperty("content")]
        public string content { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }
    }
}