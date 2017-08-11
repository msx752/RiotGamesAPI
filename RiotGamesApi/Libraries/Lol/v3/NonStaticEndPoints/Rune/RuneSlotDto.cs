using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Rune
{
    public class RuneSlotDto
    {
        //Rune slot ID.
        [JsonProperty("runeSlotId")]
        public int runeSlotId { get; set; }

        //Rune ID associated with the rune slot. For static information correlating to rune IDs, please refer to the LoL Static Data API.
        [JsonProperty("runeId")]
        public int runeId { get; set; }
    }
}