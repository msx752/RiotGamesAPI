using System;
using System.Collections.Generic;
using RiotGamesApi.Enums;

namespace RiotGamesApi.Models
{
    public class Method
    {
        public Method(LolApiMethodName md, LolApiPath[] array, Type returnValueType, ApiMethodType requestType, Type _bodyValueType, bool _isBodyRequired)
            : this(md, array, returnValueType, requestType)
        {
            BodyValueType = _bodyValueType;
            IsBodyRequired = _isBodyRequired;
        }

        public Method(LolApiMethodName md, LolApiPath[] array, Type returnValueType, ApiMethodType requestType)
        {
            this.ApiMethodName = md;
            this.RiotGamesApiPaths = array ?? new LolApiPath[0];
            ReturnValueType = returnValueType;
            TypesOfQueryParameter = new Dictionary<string, Type>();
            RequestType = requestType;
        }

        public bool IsBodyRequired { get; set; }
        public Type BodyValueType { get; set; }
        public ApiMethodType RequestType { get; set; }
        public LolApiMethodName ApiMethodName { get; set; }

        public LolApiPath[] RiotGamesApiPaths { get; set; }

        public Type ReturnValueType { get; }
        public Dictionary<string, Type> TypesOfQueryParameter { get; set; }

        /// <inheritdoc />
        ///
        public override string ToString()
        {
            string newSubUrl = $"{((Enum)ApiMethodName).GetStringValue()}/";
            for (int i = 0; i < RiotGamesApiPaths.Length; i++)
            {
                newSubUrl += $"{((Enum)RiotGamesApiPaths[i]).GetStringValue()}";
                if (i != RiotGamesApiPaths.Length - 1)
                {
                    newSubUrl += "/";
                }
            }
            return newSubUrl;
        }
    }
}