using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotGamesApi.Library.v3.NonStaticEndPoints.Champion
{
    public class ChampionListDto
    {
        [JsonProperty("champions")]
        public List<ChampionDto> Champions { get; set; }
    }
}