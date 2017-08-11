using Newtonsoft.Json;
using RiotGamesApi.Libraries.Lol.v3.StatusEndPoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StatusEndPoints
{
    public class Incident
    {
        //
        [JsonProperty("active")]
        public bool active { get; set; }

        //
        [JsonProperty("created_at")]
        public string created_at { get; set; }

        //
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("updates")]
        public List<Message> updates { get; set; }
    }
}