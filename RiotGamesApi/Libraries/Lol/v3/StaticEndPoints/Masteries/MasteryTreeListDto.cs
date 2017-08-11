using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Masteries
{
    public class MasteryTreeListDto
    {
        [JsonProperty("masteryTreeItems")]
        public List<MasteryTreeItemDto> masteryTreeItems { get; set; }
    }
}