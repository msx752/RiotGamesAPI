using System;
using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;
using RiotGamesApi.Libraries;

namespace RiotGamesApi.Libraries.Converters
{
    public class StringToEnum<TEnum> : JsonConverter where TEnum : new()
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object enumVal = null;
            try
            {
                enumVal = (TEnum)Enum.Parse(typeof(TEnum), reader.Value.ToSafetyString(), true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                enumVal = (TEnum)Enum.Parse(typeof(TEnum), "UNDEFINED", true);
            }
            return enumVal;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToSafetyString());
        }
    }
}