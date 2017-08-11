using Newtonsoft.Json;

namespace RiotGamesApi.Library.v31.NonStaticEndPoints.Champion
{
    public class ChampionDto : v3.NonStaticEndPoints.Champion.ChampionDto
    {
        [JsonIgnore]
        [JsonProperty("botEnabled")]
        public bool BotEnabled { get; set; }

        [JsonProperty("testProp")]
        public bool TestProp { get; set; }
    }
}