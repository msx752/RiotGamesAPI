using System.Collections.Generic;
using RiotGamesApi.Libraries.Lol.Enums;

namespace RiotGamesApi.Libraries.Lol.Models
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