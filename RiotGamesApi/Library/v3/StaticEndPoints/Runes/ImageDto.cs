using Newtonsoft.Json;

namespace RiotGamesApi.Library.v3.StaticEndPoints.Runes
{
    public class ImageDto
    {
        //
        [JsonProperty("full")]
        public string full { get; set; }

        //
        [JsonProperty("group")]
        public string group { get; set; }

        //
        [JsonProperty("sprite")]
        public string sprite { get; set; }

        //
        [JsonProperty("h")]
        public int h { get; set; }

        //
        [JsonProperty("w")]
        public int w { get; set; }

        //
        [JsonProperty("y")]
        public int y { get; set; }

        [JsonProperty("x")]
        public int x { get; set; }
    }
}