using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Library.v3.NonStaticEndPoints.Match;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.Match
{
    public class ParticipantDto
    {
        //
        [JsonProperty("stats")]
        public ParticipantStatsDto stats { get; set; }

        //
        [JsonProperty("participantId")]
        public int participantId { get; set; }

        //
        [JsonProperty("runes")]
        public List<RuneDto> runes { get; set; }

        //
        [JsonProperty("timeline")]
        public ParticipantTimelineDto timeline { get; set; }

        //
        [JsonProperty("teamId")]
        public int teamId { get; set; }

        //
        [JsonProperty("spell2Id")]
        public int spell2Id { get; set; }

        //
        [JsonProperty("masteries")]
        public List<MasteryDto> masteries { get; set; }

        //
        [JsonProperty("highestAchievedSeasonTier")]
        public string highestAchievedSeasonTier { get; set; }

        //
        [JsonProperty("spell1Id")]
        public int spell1Id { get; set; }

        [JsonProperty("championId")]
        public int championId { get; set; }
    }
}