using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Library.Converters;
using RiotGamesApi.Library.Enums;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.Match
{
    public class PlayerDto
    {
        //
        [JsonProperty("currentPlatformId")]
        public string currentPlatformId { get; set; }

        //
        [JsonProperty("summonerName")]
        public string summonerName { get; set; }

        //
        [JsonProperty("matchHistoryUri")]
        public string matchHistoryUri { get; set; }

        //
        [JsonConverter(typeof(StringToEnum<ServicePlatform>))]
        [JsonProperty("platformId")]
        public ServicePlatform platformId { get; set; }

        //
        [JsonProperty("currentAccountId")]
        public long currentAccountId { get; set; }

        //
        [JsonProperty("profileIcon")]
        public int profileIcon { get; set; }

        //
        [JsonProperty("summonerId")]
        public long summonerId { get; set; }

        [JsonProperty("accountId")]
        public long accountId { get; set; }
    }
}