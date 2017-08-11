using System;
using System.Collections.Generic;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.Models;
using RiotGamesApi.Models;

namespace RiotGamesApi.Interfaces
{
    public interface IApiUrl
    {
        List<LolApiMethod> ApiMethods { get; set; }
        LolApiName ApiName { get; set; }
        int LastApiMethodIndex { get; set; }
        string Version { get; set; }

        LolApiUrl AddQueryParameter(Dictionary<string, Type> queryParameterTypes);

        bool CompareVersion(double destinationVersion);

        LolApiUrl GetMethod(LolApiMethodName middleType, Type returnType, params LolApiPath[] subApis);

        double GetVersion();

        LolApiUrl PostMethod(LolApiMethodName middleType, Type returnType, Type bodyValueType, bool IsBodyRequired, params LolApiPath[] subApis);

        LolApiUrl PutMethod(LolApiMethodName methodName, Type bodyValueType, bool IsBodyRequired, params LolApiPath[] subApis);

        void SetVersion(double _version);

        string VersionToString();
    }
}