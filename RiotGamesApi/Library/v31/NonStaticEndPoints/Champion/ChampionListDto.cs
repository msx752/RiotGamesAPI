using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotGamesApi.Library.v31.NonStaticEndPoints.Champion
{
    public class ChampionListDto : v3.NonStaticEndPoints.Champion.ChampionListDto
    {
        [JsonProperty("champions")]
        public new List<ChampionDto> Champions { get; set; }
    }
}