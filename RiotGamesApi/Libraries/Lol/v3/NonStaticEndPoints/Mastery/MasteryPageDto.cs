using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Mastery
{
    public class MasteryPageDto
    {
        [JsonProperty("current")]
        public bool current { get; set; }

        [JsonProperty("masteries")]
        public List<MasteryDto> masteries { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("id")]
        public long id { get; set; }
    }
}