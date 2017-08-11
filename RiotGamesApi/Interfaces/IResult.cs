using System;

namespace RiotGamesApi.Interfaces
{
    /// <summary>
    /// Api Response Data 
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IResult<T> where T : new()
    {
        Exception Exception { get; set; }
        bool HasError { get; }
        T Result { get; set; }

        /// <summary>
        /// whether data comes from cache or not 
        /// </summary>
        bool IsCache { get; set; }
    }
}