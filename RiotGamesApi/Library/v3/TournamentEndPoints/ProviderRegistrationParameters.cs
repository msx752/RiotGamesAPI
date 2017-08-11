using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotGamesApi.Library.v3.TournamentEndPoints
{
    public class ProviderRegistrationParameters
    {
        //The provider's callback URL to which tournament game results in this region should be posted. The URL must be well-formed, use the http or https protocol, and use the default port for the protocol (http URLs must use port 80, https URLs must use port 443).
        [JsonProperty("url")]
        public string url { get; set; }

        //The region in which the provider will be running tournaments. (Legal values: BR, EUNE, EUW, JP, LAN, LAS, NA, OCE, PBE, RU, TR)
        [JsonProperty("region")]
        public string region { get; set; }
    }
}