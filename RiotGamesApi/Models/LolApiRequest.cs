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
    internal class LolApiRequest<T> :
     /*   IRSelectApi<T>,*/ IFor<T>, IAddParameter<T>, IBuild<T>, IRequestMethod<T>, IProperty<T> where T : new()
    {
        private IResult<T> _riotResult;

        public LolApiUrl ApiList { get; internal set; }
        public string BaseUrl { get; internal set; }
        public string Platform { get; private set; }

        /// <exception cref="ArgumentNullException">
        /// <paramref> <name> oldValue </name></paramref> is null. 
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="oldValue" /> is the empty string (""). 
        /// </exception>
        public string CacheKey => RequestUrl
            .Replace($"?api_key={ApiSettings.ApiOptions.RiotApiKey}", "");

        public bool Caching { get; internal set; }
        public List<ApiParameter> ParametersWithValue { get; private set; }
        public string RequestUrl { get; private set; }

        public IResult<T> RiotResult
        {
            get => _riotResult ?? (_riotResult = new RiotGamesApiResult<T>());
            set => _riotResult = value;
        }

        public int SelectedApiIndex { get; private set; } = -1;
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
        public IBuild<T> AddParameter(params ApiParameter[] parameters)
        {
            if (parameters.Any())
            {
                try
                {
                    ParametersWithValue = parameters.ToList();
                    Method selected = null;
                    foreach (var u in SelectedSubUrlCache)
                    {
                        if (u.RiotGamesApiPaths.Length != parameters.Length)
                            continue;

                        for (var i = 0; i < u.RiotGamesApiPaths.Length; i++)
                        {
                            var u1 = u;
                            if (ParametersWithValue.FirstOrDefault(p => p.Type == u1.RiotGamesApiPaths[i]) != null)
                                selected = u;
                            else
                            {
                                selected = null;
                                break;
                            }
                        }
                        if (selected != null)
                            break;
                    }
                    SelectedSubUrlCache.Clear();
                    if (selected == null)
                        throw new RiotGamesApiException("SelectedSubUrlCache is not found with this parameters");
                    SelectedApiIndex = ApiList.ApiMethods.FindIndex(p => p == selected);
                }
                catch (RiotGamesApiException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            else
            {
                SelectedSubUrlCache = SelectedSubUrlCache.Where(p => p.RiotGamesApiPaths.Count() == 0).ToList();
            }
            return this;
        }

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
            return Build(platform.ToString());
        }

        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        /// <exception cref="RiotGamesApiException">
        /// Condition. 
        /// </exception>
        /// <exception cref="Exception">
        /// Condition. 
        /// </exception>
        public IRequestMethod<T> Build(string platform)
        {
            try
            {
                Platform = platform;
                Method selected;
                if (SelectedApiIndex != -1)
                {
                    selected = ApiList.ApiMethods[SelectedApiIndex];
                }
                else
                {
                    if (SelectedSubUrlCache.Count == 1)
                        selected = SelectedSubUrlCache.First();
                    else
                        throw new RiotGamesApiException("there will be a conflict, i am not sure");
                }
                var newUrl =
                    $"{BaseUrl}/{ApiList.ApiName.GetStringValue()}/{ApiList.Version}/{selected.ApiMethodName.GetStringValue()}";
                newUrl = newUrl.Replace("{platformId}", Platform);
                var array =
                    ((LolParameterType[])Enum.GetValues(typeof(LolParameterType)))
                    .ToList();
                //url replace value
                for (int i = 0; i < selected.RiotGamesApiPaths.Length; i++)
                {
                    var parameter = selected.RiotGamesApiPaths[i];
                    newUrl = $"{newUrl}/{parameter.GetStringValue()}";
                    var prUrl = parameter.GetStringValue();
                    Regex r = new Regex("\\{\\w+\\}", RegexOptions.RightToLeft);
                    var m = r.Match(prUrl);
                    if (m.Success)
                    {
                        string nameOfParameterType = m.Value;
                        string paramStringVl = parameter.GetStringValue();
                        var para = ParametersWithValue.First(
                            p => p.Type.GetStringValue().IndexOf(paramStringVl, StringComparison.Ordinal) != -1);
                        var parameterType = array.First(p => $"{{{p.ToString()}}}" == nameOfParameterType);
                        Type paraValueGetType = para.Value.GetType();
                        string paraValueToString = para.Value.ToString();
                        if (parameterType.CompareParameterType(paraValueGetType))
                            newUrl = newUrl.Replace(nameOfParameterType, paraValueToString);
                        else
                        {
                            Type parameterTypeGetParameterType = parameterType.GetParameterType();
                            throw new RiotGamesApiException
                                ($"types of parameter value doesn't match: expected:{parameterTypeGetParameterType}, actual:{paraValueGetType}");
                        }

                        if (i == selected.RiotGamesApiPaths.Length - 1)
                        {
                            RequestUrl = newUrl;
                            break;
                        }
                    }
                    else
                    {
                        throw new RiotGamesApiException($"undefined 'parameterType' detected {prUrl}");
                    }
                }
                if (selected.RiotGamesApiPaths.Length == 0)
                {
                    RequestUrl = newUrl;
                }
            }
            catch (RiotGamesApiException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return this;
        }

        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
        /// <exception cref="Exception">
        /// Condition. 
        /// </exception>
        public IRequestMethod<T> Build(ServicePlatform platform)
        {
            return Build(platform.ToString());
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

                    await GetHttpResponse(HttpMethod.Get).ConfigureAwait(false);
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
            }).ConfigureAwait(false);
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

        /// <exception cref="IOException">
        /// An I/O error occurred. 
        /// </exception>
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

                    await GetHttpResponse(HttpMethod.Post).ConfigureAwait(false);
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
            }).ConfigureAwait(false);
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

                    await GetHttpResponse(HttpMethod.Put).ConfigureAwait(false);
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
            }).ConfigureAwait(false);
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

        private async Task<HttpResponseMessage> CreateHttpRequestMessage(HttpMethod method, StringContent data)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, RequestUrl);
            request.Headers.Add("UserAgent", "RiotGamesApi");
            request.Headers.Add("Accept-Language", "tr-TR,tr;q=0.8,en-US;q=0.6,en;q=0.4,ru;q=0.2");
            request.Headers.Add("Accept-Charset", "ISO-8859-1,UTF-8");

            var httpClient = new HttpClient();
            HttpResponseMessage response;
            if (method == HttpMethod.Get)
                response = await httpClient.GetAsync(request.RequestUri).ConfigureAwait(false);
            else if (method == HttpMethod.Post)
                response = await httpClient.PostAsync(request.RequestUri, data).ConfigureAwait(false);
            else if (method == HttpMethod.Put)
                response = await httpClient.PutAsync(request.RequestUri, data).ConfigureAwait(false);
            else
                throw new RiotGamesApiException("undefined httpMethod request");

            return response;
        }

        private async Task GetHttpResponse(HttpMethod method, object bodyData = null)
        {
            //if (UrlType != LolUrlType.Static && UrlType != LolUrlType.Status)
            {
                ApiSettings.ApiRate.Handle(Property);
                //ApiSettings.RateLimiter.Handle(Platform);
            }

            StringContent data = null;
            if (method == HttpMethod.Put || method == HttpMethod.Post)
            {
                data = bodyData != null ? new StringContent(JsonConvert.SerializeObject(bodyData)) : new StringContent("");
            }
            var response = await CreateHttpRequestMessage(method, data).ConfigureAwait(false);
            Debug.WriteLine($"----\r\n{Property}\r\n{response.Headers}\r\n----");

            if (!response.IsSuccessStatusCode)
            {
                RiotGamesApiException exp;
                switch ((int)response.StatusCode)
                {
                    case 400:
                        exp = new RiotGamesApiException($"Bad request:{(int)response.StatusCode}");
                        break;

                    case 401:
                        exp = new RiotGamesApiException($"Unauthorized:{(int)response.StatusCode}");
                        break;

                    case 403:
                        exp = new RiotGamesApiException($"Forbidden:{(int)response.StatusCode}");
                        break;

                    case 404:
                        exp = new RiotGamesApiException($"Data not found:{(int)response.StatusCode}");
                        break;

                    case 405:
                        exp = new RiotGamesApiException($"Method not allowed:{(int)response.StatusCode}");
                        break;

                    case 415:
                        exp = new RiotGamesApiException($"Unsupported media type:{(int)response.StatusCode}");
                        break;

                    case 429:
                        //handle response
                        if (ApiSettings.ApiOptions.RateLimitOptions.DisableLimiting == false)
                        {
                            var rateLimitType = response.Headers.First(p => p.Key == "X-Rate-Limit-Type").Value.First();
                            RateLimitType rType;

                            if (rateLimitType == "application")
                                rType = RateLimitType.AppRate;
                            else if (rateLimitType == "method")
                                rType = RateLimitType.MethodRate;
                            else if (rateLimitType == "service")
                                rType = RateLimitType.ServiceRate;
                            else
                                throw new RiotGamesApiException("UNDEFINED RATELIMIT TYPE: " + rateLimitType);

                            var retryseconds = response.Headers.First(p => p.Key == "Retry-After").Value.First();
                            ApiSettings.ApiRate.SetRetryTime(Property, rType, int.Parse(retryseconds));

                            exp = new RiotGamesApiException($"Limit Exceeded Retry-After:{new TimeSpan(0, 0, int.Parse(retryseconds))}, Region:{Property.Platform}, ApiType:{Property.UrlType}, ApiName:{Property.ApiName}, ApiMethod:{Property.ApiMethod} Forced-Limit:{rType}");
                        }
                        else
                        {
                            exp = new RiotGamesApiException($"Rate limit exceeded:{(int)response.StatusCode}|RateLimiting is not ACTIVE");
                        }
                        break;

                    case 500:
                        exp = new RiotGamesApiException($"Internal server error:{(int)response.StatusCode}");
                        break;

                    case 502:
                        exp = new RiotGamesApiException($"Bad gateway:{(int)response.StatusCode}");
                        break;

                    case 503:
                        exp = new RiotGamesApiException($"Service unavailable:{(int)response.StatusCode}");
                        break;

                    case 504:
                        exp = new RiotGamesApiException($"Gateway timeout:{(int)response.StatusCode}");
                        break;

                    default:
                        exp = new RiotGamesApiException($"Unknown Error code:{(int)response.StatusCode}");
                        break;
                }
                throw exp;
            }
            using (var content = response.Content)
            {
                string json = await content.ReadAsStringAsync().ConfigureAwait(false);
                RiotResult.Result = JsonConvert.DeserializeObject<T>(json);
            }

            if (Caching)
                ApiSettings.ApiCache.Add(this);
        }

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