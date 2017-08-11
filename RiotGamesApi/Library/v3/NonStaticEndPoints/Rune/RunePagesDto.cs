using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.Rune
{
    public class RunePagesDto
    {
        //Collection of rune pages associated with the summoner.
        [JsonProperty("pages")]
        public List<RunePageDto> pages { get; set; }

        //Summoner ID.
        [JsonProperty("summonerId")]
        public long summonerId { get; set; }
    }
}