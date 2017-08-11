using System;
using System.Linq;
using System.Reflection;
using RiotGamesApi.Attributes;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Models;

namespace RiotGamesApi
{
    public static class Extension3
    {
        /// <exception cref="AmbiguousMatchException">
        /// More than one of the requested attributes was found. 
        /// </exception>
        /// <exception cref="RiotGamesApiException">
        /// ParameterTypeAttribute not found 
        /// </exception>
        /// <exception cref="TypeLoadException">
        /// A custom attribute type cannot be loaded. 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="predicate" /> is null. 
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// No element satisfies the condition in <paramref name="predicate" />.-or-The source
        /// sequence is empty.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// <paramref name="element" /> is not a constructor, method, property, event, type, or field. 
        /// </exception>
        public static bool CompareParameterType(this LolParameterType enumVal, Type requestValueType)
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            var attr = v.GetCustomAttribute<ParameterTypeAttribute>();
            if (attr == null)
                throw new RiotGamesApiException("ParameterTypeAttribute not found");
            var t1 = attr.ParameterType;
            var t2 = requestValueType;
            return t1 == t2;
        }

        /// <exception cref="AmbiguousMatchException">
        /// More than one of the requested attributes was found. 
        /// </exception>
        /// <exception cref="TypeLoadException">
        /// A custom attribute type cannot be loaded. 
        /// </exception>
        /// <exception cref="RiotGamesApiException">
        /// ParameterTypeAttribute not found 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="predicate" /> is null. 
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// No element satisfies the condition in <paramref name="predicate" />.-or-The source
        /// sequence is empty.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// <paramref name="element" /> is not a constructor, method, property, event, type, or field. 
        /// </exception>
        public static Type GetParameterType(this LolParameterType enumVal)
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            var attr = v.GetCustomAttribute<ParameterTypeAttribute>();
            if (attr == null)
                throw new RiotGamesApiException("ParameterTypeAttribute not found");
            return attr.ParameterType;
        }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="match" /> is null. 
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="index" /> is less than 0.-or- <paramref name="index" /> is equal to or
        /// greater than <see cref="P:System.Collections.Generic.List`1.Count" />.
        /// </exception>
        /// <exception cref="RiotGamesApiException">
        /// ParameterTypeAttribute not found 
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="comparisonType" /> is not a <see cref="T:System.StringComparison" /> value. 
        /// </exception>
        /// <exception cref="TypeLoadException">
        /// A custom attribute type cannot be loaded. 
        /// </exception>
        /// <exception cref="AmbiguousMatchException">
        /// More than one of the requested attributes was found. 
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// <see cref="T:System.StringComparison" /> is not supported. 
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The method is invoked by reflection in a reflection-only context, -or-
        /// <paramref name="enumType" /> is a type from an assembly loaded in a reflection-only context.
        /// </exception>
        public static Type FindParameterType(this LolApiPath enumVal)
        {
            var selectedParamX = enumVal.GetStringValue().Split('{')[1].Split('}')[0];
            var array = ((LolParameterType[])Enum.GetValues(typeof(LolParameterType))).ToList();
            var found = array.FindIndex(p => string.Compare(p.ToString(), selectedParamX, StringComparison.OrdinalIgnoreCase) == 0);
            return found > -1 ? array[found].GetParameterType() : null;
        }

        /// <exception cref="AmbiguousMatchException">
        /// More than one of the requested attributes was found. 
        /// </exception>
        /// <exception cref="TypeLoadException">
        /// A custom attribute type cannot be loaded. 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="predicate" /> is null. 
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// No element satisfies the condition in <paramref name="predicate" />.-or-The source
        /// sequence is empty.
        /// </exception>
        public static string GetStringValue(this Enum enumVal)
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            var attr = v.GetCustomAttribute<StringValueAttribute>();
            return attr == null ? enumVal.ToString().ToLower() : attr.StringValue;
        }

        /// <exception cref="RiotGamesApiException">
        /// UrlTypeAttribute not found 
        /// </exception>
        /// <exception cref="AmbiguousMatchException">
        /// More than one of the requested attributes was found. 
        /// </exception>
        /// <exception cref="TypeLoadException">
        /// A custom attribute type cannot be loaded. 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="predicate" /> is null. 
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// No element satisfies the condition in <paramref name="predicate" />.-or-The source
        /// sequence is empty.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// <paramref name="element" /> is not a constructor, method, property, event, type, or field. 
        /// </exception>
        public static LolUrlType GetUrlType(this LolApiName enumVal)
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            var attr = v?.GetCustomAttribute<UrlTypeAttribute>();
            if (attr == null)
                throw new RiotGamesApiException("UrlTypeAttribute not found");
            return attr.ApiType;
        }
    }
}