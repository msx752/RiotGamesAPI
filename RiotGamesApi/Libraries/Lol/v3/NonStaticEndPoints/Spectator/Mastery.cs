using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Spectator
{
    public class Mastery
    {
        //The ID of the mastery
        [JsonProperty("masteryId")]
        public long masteryId { get; set; }

        //The number of points put into this mastery by the user
        [JsonProperty("rank")]
        public int rank { get; set; }
    }
}