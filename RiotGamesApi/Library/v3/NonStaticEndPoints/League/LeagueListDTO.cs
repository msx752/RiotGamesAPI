using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.League
{
    public class LeagueListDTO
    {
        [JsonProperty("tier")]
        public string tier { get; set; }

        [JsonProperty("queue")]
        public string queue { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("entries")]
        public List<LeagueItemDTO> entries { get; set; }
    }
}