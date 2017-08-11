using System;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;

namespace RiotGamesApi.Cache
{
    public class CustomCacheRule
    {
        public CustomCacheRule(LolUrlType urlType, LolApiName apiName, TimeSpan expiryTime)
        {
            this.UrlType = urlType;
            this.ApiName = apiName;
            this.ExpiryTime = expiryTime;
        }

        public LolApiName ApiName { get; set; }
        public TimeSpan ExpiryTime { get; set; }
        public LolUrlType UrlType { get; set; }
    }
}