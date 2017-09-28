using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Libraries.Converters;
using RiotGamesApi.Libraries.Enums;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Summoner
{
    public class SummonerDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("accountId")]
        public long AccountId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonConverter(typeof(LongToDateTime))]
        [JsonProperty("revisionDate")]
        public DateTime RevisionDate { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        public ServiceRegion Region;
    }
}