using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.LanguageStrings
{
    public class LanguageStringsDto
    {
        //
        [JsonProperty("data")]
        public Dictionary<string, string> data { get; set; }

        //
        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }
}