using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Match
{
    public class TeamStatsDto
    {
        //
        [JsonProperty("firstDragon")]
        public bool firstDragon { get; set; }

        //
        [JsonProperty("firstInhibitor")]
        public bool firstInhibitor { get; set; }

        //
        [JsonProperty("bans")]
        public List<TeamBansDto> bans { get; set; }

        //
        [JsonProperty("baronKills")]
        public int baronKills { get; set; }

        //
        [JsonProperty("firstRiftHerald")]
        public bool firstRiftHerald { get; set; }

        //
        [JsonProperty("firstBaron")]
        public bool firstBaron { get; set; }

        //
        [JsonProperty("riftHeraldKills")]
        public int riftHeraldKills { get; set; }

        //
        [JsonProperty("firstBlood")]
        public bool firstBlood { get; set; }

        //
        [JsonProperty("teamId")]
        public int teamId { get; set; }

        //
        [JsonProperty("firstTower")]
        public bool firstTower { get; set; }

        //
        [JsonProperty("vilemawKills")]
        public int vilemawKills { get; set; }

        //
        [JsonProperty("inhibitorKills")]
        public int inhibitorKills { get; set; }

        //
        [JsonProperty("towerKills")]
        public int towerKills { get; set; }

        //
        [JsonProperty("dominionVictoryScore")]
        public int dominionVictoryScore { get; set; }

        //
        [JsonProperty("win")]
        public string win { get; set; }

        [JsonProperty("dragonKills")]
        public int dragonKills { get; set; }
    }
}