using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Spectator
{
    public class FeaturedGames
    {
        //The suggested interval to wait before requesting FeaturedGames again
        [JsonProperty("clientRefreshInterval")]
        public long clientRefreshInterval { get; set; }

        //The list of featured games
        [JsonProperty("gameList")]
        public List<FeaturedGameInfo> gameList { get; set; }
    }
}