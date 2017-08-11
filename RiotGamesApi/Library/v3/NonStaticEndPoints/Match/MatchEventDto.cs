using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.Match
{
    public class MatchEventDto
    {
        //
        [JsonProperty("eventType")]
        public string eventType { get; set; }

        //
        [JsonProperty("towerType")]
        public string towerType { get; set; }

        //
        [JsonProperty("teamId")]
        public int teamId { get; set; }

        //
        [JsonProperty("ascendedType")]
        public string ascendedType { get; set; }

        //
        [JsonProperty("killerId")]
        public int killerId { get; set; }

        //
        [JsonProperty("levelUpType")]
        public string levelUpType { get; set; }

        //
        [JsonProperty("pointCaptured")]
        public string pointCaptured { get; set; }

        //
        [JsonProperty("assistingParticipantIds")]
        public List<int> assistingParticipantIds { get; set; }

        //
        [JsonProperty("wardType")]
        public string wardType { get; set; }

        //
        [JsonProperty("monsterType")]
        public string monsterType { get; set; }

        //(Legal values: CHAMPION_KILL, WARD_PLACED, WARD_KILL, BUILDING_KILL, ELITE_MONSTER_KILL, ITEM_PURCHASED, ITEM_SOLD, ITEM_DESTROYED, ITEM_UNDO, SKILL_LEVEL_UP, ASCENDED_EVENT, CAPTURE_POINT, PORO_KING_SUMMON)
        [JsonProperty("type")]
        public string type { get; set; }

        //
        [JsonProperty("skillSlot")]
        public int skillSlot { get; set; }

        //
        [JsonProperty("victimId")]
        public int victimId { get; set; }

        //
        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

        //
        [JsonProperty("afterId")]
        public int afterId { get; set; }

        //
        [JsonProperty("monsterSubType")]
        public string monsterSubType { get; set; }

        //
        [JsonProperty("laneType")]
        public string laneType { get; set; }

        //
        [JsonProperty("itemId")]
        public int itemId { get; set; }

        //
        [JsonProperty("participantId")]
        public int participantId { get; set; }

        //
        [JsonProperty("buildingType")]
        public string buildingType { get; set; }

        //
        [JsonProperty("creatorId")]
        public int creatorId { get; set; }

        //
        [JsonProperty("position")]
        public MatchPositionDto position { get; set; }

        [JsonProperty("beforeId")]
        public int beforeId { get; set; }
    }
}