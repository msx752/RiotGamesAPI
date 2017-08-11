using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.Match
{
    public class ParticipantStatsDto
    {
        //
        [JsonProperty("physicalDamageDealt")]
        public long physicalDamageDealt { get; set; }

        //
        [JsonProperty("neutralMinionsKilledTeamJungle")]
        public int neutralMinionsKilledTeamJungle { get; set; }

        //
        [JsonProperty("magicDamageDealt")]
        public long magicDamageDealt { get; set; }

        //
        [JsonProperty("totalPlayerScore")]
        public int totalPlayerScore { get; set; }

        //
        [JsonProperty("deaths")]
        public int deaths { get; set; }

        //
        [JsonProperty("win")]
        public bool win { get; set; }

        //
        [JsonProperty("neutralMinionsKilledEnemyJungle")]
        public int neutralMinionsKilledEnemyJungle { get; set; }

        //
        [JsonProperty("altarsCaptured")]
        public int altarsCaptured { get; set; }

        //
        [JsonProperty("largestCriticalStrike")]
        public int largestCriticalStrike { get; set; }

        //
        [JsonProperty("totalDamageDealt")]
        public long totalDamageDealt { get; set; }

        //
        [JsonProperty("magicDamageDealtToChampions")]
        public long magicDamageDealtToChampions { get; set; }

        //
        [JsonProperty("visionWardsBoughtInGame")]
        public int visionWardsBoughtInGame { get; set; }

        //
        [JsonProperty("damageDealtToObjectives")]
        public long damageDealtToObjectives { get; set; }

        //
        [JsonProperty("largestKillingSpree")]
        public int largestKillingSpree { get; set; }

        //
        [JsonProperty("item1")]
        public int item1 { get; set; }

        //
        [JsonProperty("quadraKills")]
        public int quadraKills { get; set; }

        //
        [JsonProperty("teamObjective")]
        public int teamObjective { get; set; }

        //
        [JsonProperty("totalTimeCrowdControlDealt")]
        public int totalTimeCrowdControlDealt { get; set; }

        //
        [JsonProperty("longestTimeSpentLiving")]
        public int longestTimeSpentLiving { get; set; }

        //
        [JsonProperty("wardsKilled")]
        public int wardsKilled { get; set; }

        //
        [JsonProperty("firstTowerAssist")]
        public bool firstTowerAssist { get; set; }

        //
        [JsonProperty("firstTowerKill")]
        public bool firstTowerKill { get; set; }

        //
        [JsonProperty("item2")]
        public int item2 { get; set; }

        //
        [JsonProperty("item3")]
        public int item3 { get; set; }

        //
        [JsonProperty("item0")]
        public int item0 { get; set; }

        //
        [JsonProperty("firstBloodAssist")]
        public bool firstBloodAssist { get; set; }

        //
        [JsonProperty("visionScore")]
        public long visionScore { get; set; }

        //
        [JsonProperty("wardsPlaced")]
        public int wardsPlaced { get; set; }

        //
        [JsonProperty("item4")]
        public int item4 { get; set; }

        //
        [JsonProperty("item5")]
        public int item5 { get; set; }

        //
        [JsonProperty("item6")]
        public int item6 { get; set; }

        //
        [JsonProperty("turretKills")]
        public int turretKills { get; set; }

        //
        [JsonProperty("tripleKills")]
        public int tripleKills { get; set; }

        //
        [JsonProperty("damageSelfMitigated")]
        public long damageSelfMitigated { get; set; }

        //
        [JsonProperty("champLevel")]
        public int champLevel { get; set; }

        //
        [JsonProperty("nodeNeutralizeAssist")]
        public int nodeNeutralizeAssist { get; set; }

        //
        [JsonProperty("firstInhibitorKill")]
        public bool firstInhibitorKill { get; set; }

        //
        [JsonProperty("goldEarned")]
        public int goldEarned { get; set; }

        //
        [JsonProperty("magicalDamageTaken")]
        public long magicalDamageTaken { get; set; }

        //
        [JsonProperty("kills")]
        public int kills { get; set; }

        //
        [JsonProperty("doubleKills")]
        public int doubleKills { get; set; }

        //
        [JsonProperty("nodeCaptureAssist")]
        public int nodeCaptureAssist { get; set; }

        //
        [JsonProperty("trueDamageTaken")]
        public long trueDamageTaken { get; set; }

        //
        [JsonProperty("nodeNeutralize")]
        public int nodeNeutralize { get; set; }

        //
        [JsonProperty("firstInhibitorAssist")]
        public bool firstInhibitorAssist { get; set; }

        //
        [JsonProperty("assists")]
        public int assists { get; set; }

        //
        [JsonProperty("unrealKills")]
        public int unrealKills { get; set; }

        //
        [JsonProperty("neutralMinionsKilled")]
        public int neutralMinionsKilled { get; set; }

        //
        [JsonProperty("objectivePlayerScore")]
        public int objectivePlayerScore { get; set; }

        //
        [JsonProperty("combatPlayerScore")]
        public int combatPlayerScore { get; set; }

        //
        [JsonProperty("damageDealtToTurrets")]
        public long damageDealtToTurrets { get; set; }

        //
        [JsonProperty("altarsNeutralized")]
        public int altarsNeutralized { get; set; }

        //
        [JsonProperty("physicalDamageDealtToChampions")]
        public long physicalDamageDealtToChampions { get; set; }

        //
        [JsonProperty("goldSpent")]
        public int goldSpent { get; set; }

        //
        [JsonProperty("trueDamageDealt")]
        public long trueDamageDealt { get; set; }

        //
        [JsonProperty("trueDamageDealtToChampions")]
        public long trueDamageDealtToChampions { get; set; }

        //
        [JsonProperty("participantId")]
        public int participantId { get; set; }

        //
        [JsonProperty("pentaKills")]
        public int pentaKills { get; set; }

        //
        [JsonProperty("totalHeal")]
        public long totalHeal { get; set; }

        //
        [JsonProperty("totalMinionsKilled")]
        public int totalMinionsKilled { get; set; }

        //
        [JsonProperty("firstBloodKill")]
        public bool firstBloodKill { get; set; }

        //
        [JsonProperty("nodeCapture")]
        public int nodeCapture { get; set; }

        //
        [JsonProperty("largestMultiKill")]
        public int largestMultiKill { get; set; }

        //
        [JsonProperty("sightWardsBoughtInGame")]
        public int sightWardsBoughtInGame { get; set; }

        //
        [JsonProperty("totalDamageDealtToChampions")]
        public long totalDamageDealtToChampions { get; set; }

        //
        [JsonProperty("totalUnitsHealed")]
        public int totalUnitsHealed { get; set; }

        //
        [JsonProperty("inhibitorKills")]
        public int inhibitorKills { get; set; }

        //
        [JsonProperty("totalScoreRank")]
        public int totalScoreRank { get; set; }

        //
        [JsonProperty("totalDamageTaken")]
        public long totalDamageTaken { get; set; }

        //
        [JsonProperty("killingSprees")]
        public int killingSprees { get; set; }

        //
        [JsonProperty("timeCCingOthers")]
        public long timeCCingOthers { get; set; }

        [JsonProperty("physicalDamageTaken")]
        public long physicalDamageTaken { get; set; }
    }
}