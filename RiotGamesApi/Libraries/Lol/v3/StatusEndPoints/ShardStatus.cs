using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Libraries.Converters;
using RiotGamesApi.Libraries.Enums;

namespace RiotGamesApi.Libraries.Lol.v3.StatusEndPoints
{
    public class ShardStatus
    {
        //
        [JsonProperty("name")]
        public string name { get; set; }

        //
        [JsonConverter(typeof(StringToEnum<ServicePlatform>))]
        [JsonProperty("region_tag")]
        public ServicePlatform region_tag { get; set; }

        //
        [JsonProperty("hostname")]
        public string hostname { get; set; }

        //
        [JsonProperty("services")]
        public List<Service> services { get; set; }

        //
        [JsonProperty("slug")]
        public string slug { get; set; }

        [JsonProperty("locales")]
        public List<string> locales { get; set; }
    }
}