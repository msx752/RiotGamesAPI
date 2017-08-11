using System.Collections.Generic;
using System.Threading.Tasks;
using RiotGamesApi.Libraries.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.Models;
using RiotGamesApi.Models;
using RiotGamesApi.RateLimit.Property;

namespace RiotGamesApi.Interfaces
{
    public interface IApiRequest<T> where T : new()
    {
        LolApiUrl ApiList { get; }
        string BaseUrl { get; }
        string CacheKey { get; }
        bool Caching { get; }
        LolApiMethodName Method { get; }
        List<ApiParameter> ParametersWithValue { get; }
        string Platform { get; }
        RateLimitProperties Property { get; }
        string RequestUrl { get; }
        IResult<T> RiotResult { get; set; }
        int SelectedApiIndex { get; }
        List<LolApiMethod> SelectedSubUrlCache { get; }
        LolUrlType UrlType { get; }

        IRequestMethod<T> Build(PhysicalRegion platform);

        IRequestMethod<T> Build(ServicePlatform platform);

        IAddParameter<T> For(LolApiMethodName middleType);

        IResult<T> Get(params QueryParameter[] optionalParameters);

        Task<IResult<T>> GetAsync(params QueryParameter[] optionalParameters);

        IResult<T> Post(object bodyParameter = null);

        IResult<T> Post(object bodyParameter = null, params QueryParameter[] optionalParameters);

        Task<IResult<T>> PostAsync(object bodyParameter = null);

        Task<IResult<T>> PostAsync(object bodyParameter = null, params QueryParameter[] optionalParameters);

        IResult<T> Put(object bodyParameter = null);

        Task<IResult<T>> PutAsync(object bodyParameter = null);

        string ToString();

        IRequestMethod<T> UseCache(bool useCache = false);
    }
}