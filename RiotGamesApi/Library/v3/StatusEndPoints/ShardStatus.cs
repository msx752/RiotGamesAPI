using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Library.Converters;
using RiotGamesApi.Library.Enums;

namespace RiotGamesApi.Library.v3.StatusEndPoints
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