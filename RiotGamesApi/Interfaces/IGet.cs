using System.Threading.Tasks;
using RiotGamesApi.Models;

namespace RiotGamesApi.Interfaces
{
    public interface IRequestMethod<T> where T : new()
    {
        string RequestUrl { get; }

        /// <summary>
        /// before using cache set EnableStaticApiCaching to True 
        /// </summary>
        /// <param name="useCache">
        /// </param>
        /// <returns>
        /// </returns>
        IRequestMethod<T> UseCache(bool useCache = false);

        Task<IResult<T>> GetAsync(params QueryParameter[] optionalParameters);

        IResult<T> Get(params QueryParameter[] optionalParameters);

        IResult<T> Put(object bodyParameter = null);

        Task<IResult<T>> PutAsync(object bodyParameter = null);

        IResult<T> Post(object bodyParameter = null);

        Task<IResult<T>> PostAsync(object bodyParameter = null);

        Task<IResult<T>> PostAsync(object bodyParameter = null, params QueryParameter[] optionalParameters);

        IResult<T> Post(object bodyParameter = null, params QueryParameter[] optionalParameters);
    }
}