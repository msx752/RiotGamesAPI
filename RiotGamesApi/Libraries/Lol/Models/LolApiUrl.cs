using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using RiotGamesApi.Enums;
using RiotGamesApi.Interfaces;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Models;

namespace RiotGamesApi.Libraries.Lol.Models
{
    /// <summary>
    /// lol apiurl creator 
    /// </summary>
    public class LolApiUrl : IApiUrl
    {
        /// <summary>
        /// lol apiurl creator 
        /// </summary>
        /// <param name="_newApiUrl">
        /// name of apiMethod 
        /// </param>
        /// <param name="_version">
        /// version of Method 
        /// </param>
        public LolApiUrl(LolApiName _newApiUrl, double _version)
        {
            ApiMethods = new List<LolApiMethod>();
            SetVersion(_version);
            ApiName = _newApiUrl;
        }

        public LolApiName ApiName { get; set; }

        public List<LolApiMethod> ApiMethods { get; set; }
        public string Version { get; set; }
        public int LastApiMethodIndex { get; set; }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="oldValue" /> is null. 
        /// </exception>
        public bool CompareVersion(double destinationVersion)
        {
            var version = destinationVersion.ToString("F1", CultureInfo.InvariantCulture);
            version = version.Replace(".0", "");
            return Version == $"v{version}";
        }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="oldValue" /> is null. 
        /// </exception>
        public void SetVersion(double _version)
        {
            var version = _version.ToString("F1", CultureInfo.InvariantCulture);
            version = version.Replace(".0", "");
            Version = $"v{version}";
        }

        /// <exception cref="OverflowException">
        /// <paramref name="s" /> represents a number that is less than
        /// <see cref="F:System.Double.MinValue" /> or greater than <see cref="F:System.Double.MaxValue" />.
        /// </exception>
        public double GetVersion()
        {
            return double.Parse(Version.Substring(1), CultureInfo.InvariantCulture);
        }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="s" /> is null. 
        /// </exception>
        public string VersionToString()
        {
            return double.Parse(Version.Substring(1), CultureInfo.InvariantCulture)
                .ToString(CultureInfo.InvariantCulture);
        }

        public LolApiUrl GetMethod(LolApiMethodName middleType, Type returnType, params LolApiPath[] subApis)
        {
            this.ApiMethods.Add(new LolApiMethod(middleType, subApis, returnType, ApiMethodType.Get));
            this.LastApiMethodIndex = this.ApiMethods.Count - 1;
            return this;
        }

        public LolApiUrl PostMethod(LolApiMethodName middleType, Type returnType, Type bodyValueType, bool IsBodyRequired,
            params LolApiPath[] subApis)
        {
            this.ApiMethods.Add(new LolApiMethod(middleType, subApis, returnType, ApiMethodType.Post, bodyValueType, IsBodyRequired));
            this.LastApiMethodIndex = this.ApiMethods.Count - 1;
            return this;
        }

        public LolApiUrl PutMethod(LolApiMethodName methodName, Type bodyValueType, bool IsBodyRequired,
            params LolApiPath[] subApis)
        {
            this.ApiMethods.Add(new LolApiMethod(methodName, subApis, typeof(int), ApiMethodType.Put, bodyValueType, IsBodyRequired));
            this.LastApiMethodIndex = this.ApiMethods.Count - 1;
            return this;
        }

        /// <summary>
        /// Query parameter for static-data and tournament apis OR Post-Request 
        /// </summary>
        /// <param name="queryParameterTypes">
        /// NameOfQuery, ValueTypeOfQuery 
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        /// <exception cref="Exception">
        /// Condition. 
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        public LolApiUrl AddQueryParameter(Dictionary<string, Type> queryParameterTypes)
        {
            try
            {
                if (this.ApiName == LolApiName.StaticData ||
                    this.ApiName == LolApiName.Tournament ||
                    this.ApiName == LolApiName.TournamentStub)
                {
                    this.ApiMethods[this.LastApiMethodIndex].TypesOfQueryParameter = queryParameterTypes;
                }
                else
                {
                    throw new RiotGamesApiException("QueryParameters only for static-data and tournament");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            return this;
        }
    }
}