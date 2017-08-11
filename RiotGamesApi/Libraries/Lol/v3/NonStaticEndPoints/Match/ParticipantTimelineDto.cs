using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Match
{
    public class ParticipantTimelineDto
    {
        //
        [JsonProperty("lane")]
        public string lane { get; set; }

        //
        [JsonProperty("participantId")]
        public int participantId { get; set; }

        //
        [JsonProperty("csDiffPerMinDeltas")]
        public Dictionary<string, double> csDiffPerMinDeltas { get; set; }

        //
        [JsonProperty("goldPerMinDeltas")]
        public Dictionary<string, double> goldPerMinDeltas { get; set; }

        //
        [JsonProperty("xpDiffPerMinDeltas")]
        public Dictionary<string, double> xpDiffPerMinDeltas { get; set; }

        //
        [JsonProperty("creepsPerMinDeltas")]
        public Dictionary<string, double> creepsPerMinDeltas { get; set; }

        //
        [JsonProperty("xpPerMinDeltas")]
        public Dictionary<string, double> xpPerMinDeltas { get; set; }

        //
        [JsonProperty("role")]
        public string role { get; set; }

        //
        [JsonProperty("damageTakenDiffPerMinDeltas")]
        public Dictionary<string, double> damageTakenDiffPerMinDeltas { get; set; }

        [JsonProperty("damageTakenPerMinDeltas")]
        public Dictionary<string, double> damageTakenPerMinDeltas { get; set; }
    }
}