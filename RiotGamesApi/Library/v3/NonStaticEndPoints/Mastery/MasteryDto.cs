using Newtonsoft.Json;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.Mastery
{
    public class MasteryDto
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("rank")]
        public int rank { get; set; }
    }
}