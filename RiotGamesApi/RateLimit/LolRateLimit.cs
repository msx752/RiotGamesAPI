using System.Collections.Generic;
using RiotGamesApi.Enums;

namespace RiotGamesApi.RateLimit
{
    public class LolRateLimit
    {
        public LolRateLimit(LolApiName name)
        {
            ApiName = name;
            ApiMethods = new List<LolApiMethodName>();
        }

        public LolApiName ApiName { get; set; }
        public List<LolApiMethodName> ApiMethods { get; set; }
    }
}