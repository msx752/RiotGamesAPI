using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.Enums;
using RiotGamesApi.Models;

namespace RiotGamesApi.Interfaces
{
    public interface IProperty<T> where T : new()
    {
        LolApiUrl ApiList { get; }
        string BaseUrl { get; }
        List<ApiParameter> ParametersWithValue { get; }
        int SelectedApiIndex { get; }
        LolUrlType UrlType { get; }
        string RequestUrl { get; }
        IResult<T> RiotResult { get; }
        String CacheKey { get; }
    }
}