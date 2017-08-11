using System.Collections.Generic;
using RiotGamesApi.Enums;

namespace RiotGamesApi.Models
{
    public class RiotGamesApi
    {
        public RiotGamesApi(string baseUrl)
        {
            ApiUrl = baseUrl;
            RiotGamesApiUrls = new List<LolApiUrl>();
        }

        public string ApiUrl { get; set; }
        public List<LolApiUrl> RiotGamesApiUrls { get; }

        public LolApiUrl AddApi(LolApiName suffix1, double version)
        {
            LolApiUrl sff1 = new LolApiUrl(suffix1, version);
            this.RiotGamesApiUrls.Add(sff1);
            return sff1;
        }
    }
}