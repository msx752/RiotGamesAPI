using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Library.v3.StaticEndPoints.Profile
{
    public class ProfileIconDetailsDto
    {
        //
        [JsonProperty("image")]
        public ImageDto image { get; set; }

        [JsonProperty("id")]
        public long id { get; set; }
    }
}