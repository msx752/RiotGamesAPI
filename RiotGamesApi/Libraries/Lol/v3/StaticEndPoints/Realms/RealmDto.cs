using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Realms
{
    public class RealmDto
    {
        //Legacy script mode for IE6 or older.
        [JsonProperty("lg")]
        public string lg { get; set; }

        //Latest changed version of Dragon Magic.
        [JsonProperty("dd")]
        public string dd { get; set; }

        //Default language for this realm.
        [JsonProperty("l")]
        public string l { get; set; }

        //Latest changed version for each data type listed.
        [JsonProperty("n")]
        public Dictionary<string, string> n { get; set; }

        //Special behavior number identifying the largest profile icon ID that can be used under 500. Any profile icon that is requested between this number and 500 should be mapped to 0.
        [JsonProperty("profileiconmax")]
        public int profileiconmax { get; set; }

        //Additional API data drawn from other sources that may be related to Data Dragon functionality.
        [JsonProperty("store")]
        public string store { get; set; }

        //Current version of this file for this realm.
        [JsonProperty("v")]
        public string v { get; set; }

        //The base CDN URL.
        [JsonProperty("cdn")]
        public string cdn { get; set; }

        //Latest changed version of Dragon Magic's CSS file.
        [JsonProperty("css")]
        public string css { get; set; }
    }
}