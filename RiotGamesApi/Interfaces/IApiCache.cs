using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Interfaces
{
    public interface IApiCache
    {
        /// <summary>
        /// add to cache 
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="data">
        /// </param>
        void Add<T>(IProperty<T> data) where T : new();

        bool Get<T>(IProperty<T> data, out T cachedData) where T : new();

        void Remove<T>(IProperty<T> data) where T : new();
    }
}