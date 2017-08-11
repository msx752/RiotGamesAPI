using Newtonsoft.Json;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.League
{
    public class LeaguePositionDTO
    {
        [JsonProperty("rank")]
        public string rank { get; set; }

        [JsonProperty("queueType")]
        public string queueType { get; set; }

        [JsonProperty("hotStreak")]
        public bool hotStreak { get; set; }

        [JsonProperty("miniSeries")]
        public MiniSeriesDTO miniSeries { get; set; }

        [JsonProperty("wins")]
        public int wins { get; set; }

        [JsonProperty("veteran")]
        public bool veteran { get; set; }

        [JsonProperty("losses")]
        public int losses { get; set; }

        [JsonProperty("playerOrTeamId")]
        public string playerOrTeamId { get; set; }

        [JsonProperty("leagueName")]
        public string leagueName { get; set; }

        [JsonProperty("playerOrTeamName")]
        public string playerOrTeamName { get; set; }

        [JsonProperty("inactive")]
        public bool inactive { get; set; }

        [JsonProperty("freshBlood")]
        public bool freshBlood { get; set; }

        [JsonProperty("tier")]
        public string tier { get; set; }

        [JsonProperty("leaguePoints")]
        public int leaguePoints { get; set; }
    }
}