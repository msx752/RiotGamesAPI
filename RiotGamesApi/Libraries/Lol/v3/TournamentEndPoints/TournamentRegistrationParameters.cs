using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.Libraries.Lol.v3.TournamentEndPoints
{
    public class TournamentRegistrationParameters
    {
        //The provider ID to specify the regional registered provider data to associate this tournament.
        [JsonProperty("providerId")]
        public int providerId { get; set; }

        //The optional name of the tournament.
        [JsonProperty("name")]
        public string name { get; set; }
    }
}