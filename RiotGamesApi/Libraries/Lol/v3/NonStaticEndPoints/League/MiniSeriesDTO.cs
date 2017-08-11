using Newtonsoft.Json;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.League
{
    public class MiniSeriesDTO
    {
        [JsonProperty("progress")]
        public string Progress { get; set; }

        [JsonProperty("target")]
        public int Target { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}