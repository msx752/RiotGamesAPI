using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.Match
{
    public class MatchParticipantFrameDto
    {
        //
        [JsonProperty("totalGold")]
        public int totalGold { get; set; }

        //
        [JsonProperty("teamScore")]
        public int teamScore { get; set; }

        //
        [JsonProperty("participantId")]
        public int participantId { get; set; }

        //
        [JsonProperty("level")]
        public int level { get; set; }

        //
        [JsonProperty("currentGold")]
        public int currentGold { get; set; }

        //
        [JsonProperty("minionsKilled")]
        public int minionsKilled { get; set; }

        //
        [JsonProperty("dominionScore")]
        public int dominionScore { get; set; }

        //
        [JsonProperty("position")]
        public MatchPositionDto position { get; set; }

        //
        [JsonProperty("xp")]
        public int xp { get; set; }

        [JsonProperty("jungleMinionsKilled")]
        public int jungleMinionsKilled { get; set; }
    }
}