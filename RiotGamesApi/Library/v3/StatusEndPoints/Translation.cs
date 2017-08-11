using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Library.Converters;
using RiotGamesApi.Library.Enums;

namespace RiotGamesApi.Library.v3.StatusEndPoints
{
    public class Translation
    {
        //
        [JsonConverter(typeof(StringToEnum<Language>))]
        [JsonProperty("locale")]
        public Language locale { get; set; }

        //
        [JsonProperty("content")]
        public string content { get; set; }

        [JsonProperty("updated_at")]
        public string updated_at { get; set; }
    }
}