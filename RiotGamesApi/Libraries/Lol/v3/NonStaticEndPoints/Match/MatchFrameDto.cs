using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Match
{
    public class MatchFrameDto
    {
        //
        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

        //
        [JsonProperty("participantFrames")]
        public Dictionary<int, MatchParticipantFrameDto> participantFrames { get; set; }

        [JsonProperty("events")]
        public List<MatchEventDto> events { get; set; }
    }
}