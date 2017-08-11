using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;

namespace RiotGamesApi.Models
{
    public class ApiParameter
    {
        /// <summary>
        /// url path parameter for apis 
        /// </summary>
        /// <param name="subApiType">
        /// Name of UrlPath 
        /// </param>
        /// <param name="value">
        /// value of UrlPath 
        /// </param>
        public ApiParameter(LolApiPath subApiType, object value)
        {
            this.Type = subApiType;
            this.Value = value;
        }

        public LolApiPath Type { get; private set; }
        public object Value { get; private set; }
    }
}