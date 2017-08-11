using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Masteries
{
    public class MasteryTreeItemDto
    {
        //
        [JsonProperty("masteryId")]
        public int masteryId { get; set; }

        [JsonProperty("prereq")]
        public string prereq { get; set; }
    }
}