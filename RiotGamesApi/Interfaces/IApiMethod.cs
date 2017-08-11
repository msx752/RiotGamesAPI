using System;
using System.Collections.Generic;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;

namespace RiotGamesApi.Interfaces
{
    public interface IApiMethod
    {
        LolApiMethodName ApiMethodName { get; set; }
        Type BodyValueType { get; set; }
        bool IsBodyRequired { get; set; }
        ApiMethodType RequestType { get; set; }
        Type ReturnValueType { get; }
        LolApiPath[] RiotGamesApiPaths { get; set; }
        Dictionary<string, Type> TypesOfQueryParameter { get; set; }

        string ToString();
    }
}