using System;
using Newtonsoft.Json;
using RiotGamesApi.Library.Converters;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.ChampionMastery
{
    public class ChampionMasteryDto
    {
        [JsonProperty("championPoints")]
        public int ChampionPoints { get; set; }

        [JsonProperty("playerId")]
        public long PlayerId { get; set; }

        [JsonProperty("championPointsUntilNextLevel")]
        public int ChampionPointsUntilNextLevel { get; set; }

        [JsonProperty("chestGranted")]
        public bool ChestGranted { get; set; }

        [JsonProperty("championLevel")]
        public int ChampionLevel { get; set; }

        [JsonProperty("championId")]
        public long ChampionId { get; set; }

        [JsonProperty("championPointsSinceLastLevel")]
        public long ChampionPointsSinceLastLevel { get; set; }

        [JsonConverter(typeof(LongToDateTime))]
        [JsonProperty("lastPlayTime")]
        public DateTime LastPlayTime { get; set; }
    }
}