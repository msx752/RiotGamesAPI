using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotGamesApi.Enums;
using RiotGamesApi.Interfaces;
using RiotGamesApi.Library.Enums;
using RiotGamesApi.RateLimit.Property;

namespace RiotGamesApi.Models
{
    /// <summary>
    /// fluent api requesting 
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class LolApiRequest<T> :

      /*   IRSelectApi<T>,*/ IFor<T>, IAddParameter<T>, IBuild<T>, IRequestMethod<T>, IProperty<T> where T : new()
    {
        private IResult<T> _riotResult;

        public LolApiUrl ApiList { get; internal set; }
        public string BaseUrl { get; internal set; }
        public string Platform { get; protected internal set; }

        /// <exception cref="ArgumentNullException">
        /// <paramref> <name> oldValue </name></paramref> is null. 
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="oldValue" /> is the empty string (""). 
        /// </exception>
        public string CacheKey => RequestUrl
            .Replace($"?api_key={ApiSettings.ApiOptions.RiotApiKey}", "");

        public bool Caching { get; internal set; }
        public List<ApiParameter> ParametersWithValue { get; protected internal set; }
        public string RequestUrl { get; protected internal set; }

        public IResult<T> RiotResult
        {
            get => _riotResult ?? (_riotResult = new RiotGamesApiResult<T>());
            set => _riotResult = value;
        }

        public int SelectedApiIndex { get; protected internal set; } = -1;
        public List<Method> SelectedSubUrlCache { get; internal set; }
        public LolUrlType UrlType { get; internal set; }
        public LolApiMethodName Method { get; internal set; }

        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        /// <exception cref="RiotGamesApiException">
        /// Condition. 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref> <name> source </name></paramref> is null. 
        /// </exception>
        /// <exception cref="Exception">
        /// Condition. 
        /// </exception>
        /// <exception cref="OverflowException">
        /// The number of elements in <paramref name="source" /> is larger than <see cref="F:System.Int32.MaxValue" />. 
        /// </exception>

        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        /// <exception cref="RiotGamesApiException">
        /// Condition. 
        /// </exception>
        /// <exception cref="Exception">
        /// Condition. 
        /// </exception>
        public IRequestMethod<T> Build(PhysicalRegion platform)
        {
            return this.Build(platform.ToString());
        }

        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        /// <exception cref="Exception">
        /// Condition. 
        /// </exception>
        public IRequestMethod<T> Build(ServicePlatform platform)
        {
            return this.Build(platform.ToString());
        }

        public IAddParameter<T> For(LolApiMethodName middleType)
        {
            SelectedSubUrlCache = ApiList.ApiMethods.Where(p => p.ApiMethodName == middleType).ToList();
            Method = middleType;
            return this;
        }

        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="T:System.Threading.Tasks.Task" /> has been disposed. 
        /// </exception>
        /// <exception cref="AggregateException">
        /// The task was canceled. The <see cref="P:System.AggregateException.InnerExceptions" />
        /// collection contains a <see cref="T:System.Threading.Tasks.TaskCanceledException" />
        /// object. -or-An exception was thrown during the execution of the task. The
        /// <see cref="P:System.AggregateException.InnerExceptions" /> collection contains
        /// information about the exception or exceptions.
        /// </exception>
        public IResult<T> Get(params QueryParameter[] optionalParameters)
        {
            GetAsync(optionalParameters).Wait();
            return RiotResult;
        }

        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The <paramref> <name> function </name></paramref> parameter was null. 
        /// </exception>
        public async Task<IResult<T>> GetAsync(params QueryParameter[] optionalParameters)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    RegisterApiKey();
                    RegisterQueryParameter(optionalParameters);
                    if (CacheControl())
                        return RiotResult;

                    await this.GetHttpResponseAsync(HttpMethod.Get);
                }
                catch (RiotGamesApiException e)
                {
                    RiotResult.Exception = e;
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    RiotResult.Exception = e;
                    Console.WriteLine(e);
                }
                return RiotResult;
            });
        }

        public IResult<T> Post(object bodyParameter = null)
        {
            return Post(bodyParameter, new QueryParameter());
        }

        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        public IResult<T> Post(object bodyParameter = null, params QueryParameter[] optionalParameters)
        {
            PostAsync(bodyParameter, optionalParameters).Wait();
            return RiotResult;
        }

        public Task<IResult<T>> PostAsync(object bodyParameter = null)
        {
            return PostAsync(bodyParameter, new QueryParameter());
        }

        /// <exception cref="ArgumentNullException">
        /// The <paramref> <name> function </name></paramref> parameter was null. 
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        public async Task<IResult<T>> PostAsync(object bodyParameter = null, params QueryParameter[] optionalParameters)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    RegisterApiKey();
                    RegisterQueryParameter(optionalParameters);
                    if (CacheControl())
                        return RiotResult;

                    await this.GetHttpResponseAsync(HttpMethod.Post);
                }
                catch (RiotGamesApiException e)
                {
                    RiotResult.Exception = e;
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    RiotResult.Exception = e;
                    Console.WriteLine(e);
                }
                return RiotResult;
            });
        }

        /// <exception cref="AggregateException">
        /// The task was canceled. The <see cref="P:System.AggregateException.InnerExceptions" />
        /// collection contains a <see cref="T:System.Threading.Tasks.TaskCanceledException" />
        /// object. -or-An exception was thrown during the execution of the task. The
        /// <see cref="P:System.AggregateException.InnerExceptions" /> collection contains
        /// information about the exception or exceptions.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="T:System.Threading.Tasks.Task" /> has been disposed. 
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        public IResult<T> Put(object bodyParameter = null)
        {
            PutAsync(bodyParameter).Wait();
            return RiotResult;
        }

        public async Task<IResult<T>> PutAsync(object bodyParameter = null)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    RegisterApiKey();
                    if (CacheControl())
                        return RiotResult;

                    await this.GetHttpResponseAsync(HttpMethod.Put);
                }
                catch (RiotGamesApiException e)
                {
                    RiotResult.Exception = e;
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    RiotResult.Exception = e;
                    Console.WriteLine(e);
                }
                return RiotResult;
            });
        }

        public override string ToString()
        {
            return RequestUrl ?? base.ToString();
        }

        public IRequestMethod<T> UseCache(bool useCache = false)
        {
            if (ApiSettings.ApiOptions.CacheOptions.EnableStaticApiCaching && UrlType == LolUrlType.Static)
                Caching = useCache;
            else
                Caching = false;

            return this;
        }

        private bool CacheControl()
        {
            if (UrlType != LolUrlType.Static)//custom api rules
            {
                if (ApiSettings.ApiOptions.CacheOptions.EnableStaticApiCaching)
                {
                    var found = ApiSettings.ApiOptions.CacheOptions.FindCacheRule(UrlType, ApiList.ApiName);
                    Caching = found != null;
                }
            }

            if (!Caching) return false;
            var rslt = ApiSettings.ApiCache.Get(this, out T data);
            if (!rslt) return false;
            RiotResult.IsCache = true;
            RiotResult.Result = data;
            return true;
        }

        public RateLimitProperties Property => new RateLimitProperties
        {
            UrlType = UrlType,
            Platform = Platform,
            ApiName = ApiList.ApiName,
            ApiMethod = Method
        };

        private void RegisterApiKey()
        {
            if (string.IsNullOrWhiteSpace(ApiSettings.ApiOptions.RiotApiKey))
                throw new RiotGamesApiException("api_key is not found, please set key to 'RiotApiMain.Api_Key' ");
            RequestUrl += $"?api_key={ApiSettings.ApiOptions.RiotApiKey}";
        }

        private void RegisterQueryParameter(params QueryParameter[] optionalParameters)
        {
            if (optionalParameters.Count() == 0) return;
            foreach (var parameter in optionalParameters)
            {
                if (parameter.Value != null && !string.IsNullOrWhiteSpace(parameter.Value.ToString()))
                    RequestUrl += $"&{parameter.Key}={parameter.Value}";
            }
        }
    }
}