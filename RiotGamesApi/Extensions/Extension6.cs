using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotGamesApi.Enums;
using RiotGamesApi.Interfaces;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.Models;
using RiotGamesApi.Models;

namespace RiotGamesApi
{
	public static class Extension6
	{
		/// <summary>
		/// url path parameter for apis 
		/// </summary>
		/// <typeparam name="T">
		/// response type of value 
		/// </typeparam>
		public static IBuild<T> AddParameter<T>(this IAddParameter<T> lar, params ApiParameter[] parameters) where T : new()
		{
			if (parameters.Any())
			{
				try
				{
					((LolApiRequest<T>)lar).ParametersWithValue = parameters.ToList();
					LolApiMethod selected = null;
					foreach (var u in ((LolApiRequest<T>)lar).SelectedSubUrlCache)
					{
						if (u.RiotGamesApiPaths.Length != parameters.Length)
							continue;

						for (var i = 0; i < u.RiotGamesApiPaths.Length; i++)
						{
							var u1 = u;
							if (((LolApiRequest<T>)lar).ParametersWithValue.FirstOrDefault(p => p.Type == u1.RiotGamesApiPaths[i]) != null)

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
					((LolApiRequest<T>)lar).SelectedSubUrlCache.Clear();
					if (selected == null)
						throw new RiotGamesApiException("SelectedSubUrlCache is not found with this parameters");
					((LolApiRequest<T>)lar).SelectedApiIndex = ((LolApiRequest<T>)lar).ApiList.ApiMethods.FindIndex(p => p == selected);
				}
				catch (RiotGamesApiException e)
				{
					Debug.WriteLine(e);
					throw;
				}
				catch (Exception e)
				{
					Debug.WriteLine(e);
					throw;
				}
			}
			else
			{
				((LolApiRequest<T>)lar).SelectedSubUrlCache = ((LolApiRequest<T>)lar).SelectedSubUrlCache.Where(p => p.RiotGamesApiPaths.Count() == 0).ToList();
			}
			return ((IBuild<T>)lar);
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
		public static IRequestMethod<T> Build<T>(this LolApiRequest<T> lar, string platform) where T : new()
		{
			try
			{
				lar.Platform = platform;
				LolApiMethod selected;
				if (lar.SelectedApiIndex != -1)
				{
					selected = lar.ApiList.ApiMethods[lar.SelectedApiIndex];
				}
				else
				{
					if (lar.SelectedSubUrlCache.Count == 1)
						selected = lar.SelectedSubUrlCache.First();
					else
						throw new RiotGamesApiException("there will be a conflict, i am not sure");
				}
				var newUrl =
					$"{lar.BaseUrl}/{lar.ApiList.ApiName.GetStringValue()}/{lar.ApiList.Version}/{selected.ApiMethodName.GetStringValue()}";
				newUrl = newUrl.Replace("{platformId}", lar.Platform);
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
						var para = lar.ParametersWithValue.First(
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
							lar.RequestUrl = newUrl;
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
					lar.RequestUrl = newUrl;
				}
			}
			catch (RiotGamesApiException e)
			{
				Debug.WriteLine(e);
				throw;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
				throw;
			}
			return lar;
		}

		public static async Task<HttpResponseMessage> CreateHttpRequestMessageAsync<T>(this LolApiRequest<T> lar, HttpMethod method, StringContent data) where T : new()
		{
			var request = new HttpRequestMessage(HttpMethod.Get, lar.RequestUrl);
			request.Headers.Add("UserAgent", "RiotGamesApi");
			request.Headers.Add("Accept-Language", "tr-TR,tr;q=0.8,en-US;q=0.6,en;q=0.4,ru;q=0.2");
			request.Headers.Add("Accept-Charset", "ISO-8859-1,UTF-8");

			var httpClient = new HttpClient();
			HttpResponseMessage response;
			if (method == HttpMethod.Get)
				response = await httpClient.GetAsync(request.RequestUri);
			else if (method == HttpMethod.Post)
				response = await httpClient.PostAsync(request.RequestUri, data);
			else if (method == HttpMethod.Put)
				response = await httpClient.PutAsync(request.RequestUri, data);
			else
				throw new RiotGamesApiException("undefined httpMethod request");

			return response;
		}

		public static async Task GetHttpResponseAsync<T>(this LolApiRequest<T> lar, HttpMethod method, object bodyData = null) where T : new()
		{
			//if (UrlType != LolUrlType.Static && UrlType != LolUrlType.Status)
			{
				ApiSettings.ApiRate.Handle(lar.Property);
				//ApiSettings.RateLimiter.Handle(Platform);
			}

			StringContent data = null;
			if (method == HttpMethod.Put || method == HttpMethod.Post)
			{
				data = bodyData != null ? new StringContent(JsonConvert.SerializeObject(bodyData)) : new StringContent("");
			}
			var response = await lar.CreateHttpRequestMessageAsync(method, data);
			Debug.WriteLine($"----\r\n{lar.Property}\r\n{response.Headers}\r\n----");

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
							ApiSettings.ApiRate.SetRetryTime(lar.Property, rType, int.Parse(retryseconds));

							exp = new RiotGamesApiException($"Limit Exceeded Retry-After:{new TimeSpan(0, 0, int.Parse(retryseconds))}, Region:{lar.Property.Platform}, ApiType:{lar.Property.UrlType}, ApiName:{lar.Property.ApiName}, ApiMethod:{lar.Property.ApiMethod} Forced-Limit:{rType}");
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
				string json = await content.ReadAsStringAsync();
				lar.RiotResult.Result = JsonConvert.DeserializeObject<T>(json);
			}

			if (lar.Caching)
			{
				lar.RiotResult.CurrentXMethodRateLimit = lar.RiotResult.CurrentXAppRateLimit = "cached";
				ApiSettings.ApiCache.Add(lar);
			}
			else
			{
				var appRate = response.Headers.First(p => p.Key == "X-App-Rate-Limit-Count").Value.First();
				var methodRate = response.Headers.First(p => p.Key == "X-Method-Rate-Limit-Count").Value.First();
				lar.RiotResult.CurrentXAppRateLimit = appRate;
				lar.RiotResult.CurrentXMethodRateLimit = methodRate;
			}
		}
	}
}