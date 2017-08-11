using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotGamesApi.Libraries.Lol.v31.NonStaticEndPoints.Champion
{
    public class ChampionListDto : Lol.v3.NonStaticEndPoints.Champion.ChampionListDto
    {
        [JsonProperty("champions")]
        public new List<ChampionDto> Champions { get; set; }
    }
}