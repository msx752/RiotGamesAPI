using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Libraries.Converters;
using RiotGamesApi.Libraries.Enums;

namespace RiotGamesApi.Libraries.Lol.v3.StatusEndPoints
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