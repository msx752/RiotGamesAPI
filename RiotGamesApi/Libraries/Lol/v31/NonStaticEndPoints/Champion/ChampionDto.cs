using Newtonsoft.Json;

namespace RiotGamesApi.Libraries.Lol.v31.NonStaticEndPoints.Champion
{
    public class ChampionDto : Lol.v3.NonStaticEndPoints.Champion.ChampionDto
    {
        [JsonIgnore]
        [JsonProperty("botEnabled")]
        public bool BotEnabled { get; set; }

        [JsonProperty("testProp")]
        public bool TestProp { get; set; }
    }
}