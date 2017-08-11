using System.Collections.Generic;
using Newtonsoft.Json;
using RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Champion;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Champion
{
    public class ChampionListDto
    {
        [JsonProperty("champions")]
        public List<ChampionDto> Champions { get; set; }
    }
}