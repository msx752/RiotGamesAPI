using System;
using System.Collections.Generic;
using System.Reflection;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Models;

namespace RiotGamesApi
{
    public static class Extension5
    {
        #region api class generetor

        public static string GenerateLolApiClass()
        {
            string nameOfNs = typeof(ApiSettings).Namespace;
            Dictionary<LolUrlType, string> Classes = new Dictionary<LolUrlType, string>();
            string @apiClassProperties = $"";
            foreach (var selected in ApiSettings.ApiOptions.RiotGamesApis)
            {
                var urlType = selected.Key;
                string @class = $"\r\n//\"{selected.Value.ApiUrl}\r\n" +
                                $"public class {urlType.ToString()}\r\n{{";
                @apiClassProperties += $"private {urlType.ToString()} _{urlType.ToString().ToLower()}Api;\r\n" +
                                       $"public {urlType.ToString()} {urlType.ToString()}Api {{ get {{ return _{urlType.ToString().ToLower()}Api ?? (_{urlType.ToString().ToLower()}Api = new {urlType.ToString()}()); }} }}\r\n";
                foreach (var url in selected.Value.RiotGamesApiUrls)
                {
                    string ClassName = $"{url.ApiName}_{url.Version.Replace(".", "_")}";
                    string @class2 = $"\r\n//\"{url.ApiName}/{url.Version}\r\n" +
                                     $"public class {ClassName}\r\n{{";

                    string @property = $"\r\nprivate {ClassName} _{ClassName.Replace("_", "")};\r\n" +
                                       $"public {ClassName} {ClassName.Replace("_", "")} {{ get {{ return _{ClassName.Replace("_", "")} ?? (_{ClassName.Replace("_", "")} = new {ClassName}()); }} }}\r\n";
                    @class += @property;
                    foreach (var urlSub in url.ApiMethods)
                    {
                        TypeInfo tinf = urlSub.ReturnValueType.GetTypeInfo();
                        string t1_ns = urlSub.ReturnValueType.Namespace;
                        var t1 = "";
                        if (urlSub.ReturnValueType.Name == "List`1")
                        {
                            string t2 =
                                urlSub.ReturnValueType.FullName.Split(new string[] { "[[" }, StringSplitOptions.None)[1]
                                    .Split(new string[] { "," }, StringSplitOptions.None)[0];
                            t1 = $"List<{t2}>";
                        }
                        else
                        {
                            if (tinf.IsClass || tinf.IsInterface)
                            {
                                t1 = $"{t1_ns}.{urlSub.ReturnValueType.Name}";
                            }
                            else
                            {
                                t1 = $"{urlSub.ReturnValueType.Name}";
                            }
                        }
                        string @parameters = "";
                        string @RiotGamesApiParameters = "";
                        string @SecondaryMethodRefParameters = $"";
                        LolApiPath? uniqueParam = null;
                        for (int i = 0; i < urlSub.RiotGamesApiPaths.Length; i++)
                        {
                            var selectedParam = urlSub.RiotGamesApiPaths[i];
                            if (!uniqueParam.HasValue)
                            {
                                uniqueParam = selectedParam;
                            }
                            string paramName = selectedParam.ToString();

                            string paramType = selectedParam.FindParameterType().Name;
                            @parameters += $", {paramType} _{paramName}";
                            @SecondaryMethodRefParameters += $",_{paramName}";
                            @RiotGamesApiParameters += $"new {nameof(ApiParameter)}({nameof(LolApiPath)}.{paramName}, _{paramName})";
                            if (i != urlSub.RiotGamesApiPaths.Length - 1)
                            {
                                @RiotGamesApiParameters += ",\r\n";
                            }
                        }
                        string @useCacheMethod = "";
                        if (selected.Key == LolUrlType.Static)//useCache parameter
                        {
                            @parameters += ", bool _useCache = false";
                            @useCacheMethod = $".UseCache(_useCache)\r\n";

                            @SecondaryMethodRefParameters += $",_useCache";
                        }
                        string @queryParameters = "";
                        string @optionalParameters = "";
                        foreach (var query in urlSub.TypesOfQueryParameter)
                        {
                            string paramName = $"_{query.Key}";
                            string paramType = query.Value.Name;
                            if (paramType == "List`1")
                            {
                                string paramType_t2 =
                                    query.Value.FullName.Split(new string[] { "[[" }, StringSplitOptions.None)[1]
                                        .Split(new string[] { "," }, StringSplitOptions.None)[0];
                                paramType = $"List<{paramType_t2}>";
                            }
                            string @defaultParamValue = paramType == "Boolean" ? "false" : "null";
                            if (IsDigitType(paramType))
                            {
                                paramType += "?";
                            }
                            @queryParameters += $", {paramType} {paramName} = {@defaultParamValue}";
                            @SecondaryMethodRefParameters += $",{paramName}";
                            if (paramType.StartsWith("List<"))
                            {
                                optionalParameters += $"new QueryParameter(\"{query.Key}\", string.Join(\"&tags=\", {paramName}  ?? new {paramType}()) ),\r\n";
                                //@optionalParameters += $"{{\"{query.Key}\",string.Join(\"&tags=\", {paramName}  ?? new {paramType}()) }},\r\n";
                            }
                            else
                            {
                                if (paramType == "Boolean")
                                {
                                    @optionalParameters += $"new QueryParameter(\"{query.Key}\",{paramName}.ToString().ToLower()),\r\n";
                                    //@optionalParameters += $"{{\"{query.Key}\",{paramName}.ToString().ToLower() }},\r\n";
                                }
                                else
                                {
                                    @optionalParameters += $"new QueryParameter(\"{query.Key}\",{paramName}),\r\n";
                                    //@optionalParameters += $"{{\"{query.Key}\",{paramName} }},\r\n";
                                }
                            }
                        }
                        @optionalParameters = @optionalParameters.TrimEnd('\n').TrimEnd('\r').TrimEnd(',');
                        @optionalParameters += "\r\n";
                        if (!string.IsNullOrWhiteSpace(@queryParameters))
                        {
                            @parameters += @queryParameters;
                        }
                        else
                        {
                            @optionalParameters = "";
                        }
                        string platformName = "";
                        if (urlType == LolUrlType.Tournament)
                        {
                            platformName = nameof(PhysicalRegion);
                            if (urlSub.RequestType != ApiMethodType.Get)
                            {
                                string bodyParam = $"_{urlSub.BodyValueType.Name.ToLower()}";
                                string @mergedParameters = $",{urlSub.BodyValueType.Namespace}.{urlSub.BodyValueType.Name} {bodyParam}";
                                if (urlSub.IsBodyRequired)
                                {
                                    var cacheParams = @parameters;
                                    mergedParameters += cacheParams;
                                    @parameters = mergedParameters;

                                    var cacheSecondaryPrm = @SecondaryMethodRefParameters;
                                    string mergedSecondaryParam = $",{bodyParam}{cacheSecondaryPrm}";
                                    @SecondaryMethodRefParameters = mergedSecondaryParam;
                                }
                                else
                                {
                                    @parameters += $"{mergedParameters} = null";
                                    @SecondaryMethodRefParameters += $",{bodyParam}";
                                }
                                if (@optionalParameters.Length > 0)
                                    @optionalParameters += ",";
                                @optionalParameters = bodyParam + ",\r\n" + @optionalParameters;

                                @optionalParameters = @optionalParameters.TrimEnd('\n').TrimEnd('\r').TrimEnd(',');
                            }
                        }
                        else
                        {
                            platformName = nameof(ServicePlatform);
                        }
                        string methodName = $"{urlSub.RequestType}{urlSub.ApiMethodName}{uniqueParam}";
                        string @methodSync = $"\r\npublic {nameOfNs}.Interfaces.IResult<{t1}> {methodName}({platformName} platform{@parameters})\r\n{{";
                        methodSync += $"var t = {methodName}Async(platform{@SecondaryMethodRefParameters});\r\n" +
                                      $"t.Wait();\r\n" +
                                      $"{nameOfNs}.Interfaces.IResult<{t1}> rit = t.Result;\r\n" +
                                      $"return rit;\r\n" +
                                      $"}}\r\n";

                        string @methodAsync = $"{@methodSync}\r\npublic async Task<{nameOfNs}.Interfaces.IResult<{t1}>> {methodName}Async({platformName} platform{@parameters})\r\n{{";

                        string @apiCall = $"\r\n{nameOfNs}.Interfaces.IResult<{t1}> rit = await new {nameof(ApiCall)}()\r\n" +
                                          $".SelectApi<{t1}>({nameof(LolApiName)}.{url.ApiName},{url.VersionToString()})\r\n" +
                                          $".For({nameof(LolApiMethodName)}.{urlSub.ApiMethodName})\r\n" +
                                          $".AddParameter({@RiotGamesApiParameters})\r\n" +
                                          ".Build(platform)\r\n" +
                                          @useCacheMethod +
                                          $".{urlSub.RequestType}Async({@optionalParameters});";
                        @methodAsync += @apiCall;
                        @methodAsync += "\r\nreturn rit;\r\n}";
                        class2 += @methodAsync;
                    }
                    @class2 += "\r\n}";
                    @class += @class2;
                }

                @class += "\r\n}\r\n";
                Classes[urlType] = @class;
            }
            string @references = Reference(nameOfNs);
            string @namespaces = @references + $"\r\nnamespace {nameOfNs}\r\n{{";
            string @MainClass = $"\r\n// ReSharper disable InconsistentNaming\r\n" +
                                $"//AUTO GENERATED CLASS DO NOT MODIFY\r\n ";

            string @apiClass = $"public class {nameof(LolApi)}\r\n{{\r\n" +
                               $"{@apiClassProperties}" +
                               $"\r\n}}\r\n";
            MainClass += @apiClass;
            foreach (var clss in Classes)
            {
                @MainClass += $"//{clss.Key} API" + clss.Value;
            }
            @MainClass += "//\r\n}\r\n";
            @namespaces += @MainClass;

            Classes.Clear();
            return @namespaces;
        }

        private static bool IsDigitType(string value)
        {
            if (value.StartsWith("Int") ||
                value.StartsWith("long") ||
                value.StartsWith("byte") ||
                value.Equals("int") ||
                value.StartsWith("decimal") ||
                value.StartsWith("double"))
            {
                return true;
            }

            return false;
        }

        private static string Reference(string Namespace)
        {
            string @references = $"using {Namespace}.Enums;\r\n" +
                                 $"using {Namespace}.Models;\r\n" +
                                 $"using System;\r\n" +
                                 $"using System.Collections.Generic;\r\n" +
                                 $"using System.Threading.Tasks;\r\n" +
                                 $"using {Namespace}.Libraries.Enums;\r\n" +
                                 $"using {Namespace}.Libraries.Lol.Enums;\r\n" +
                                 $"using {Namespace}.Libraries.Lol.Enums.GameConstants; ";

            return @references;
        }

        #endregion api class generetor
    }
}