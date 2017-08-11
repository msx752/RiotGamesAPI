using System;
using System.Reflection;
using Newtonsoft.Json;
using RiotGamesApi.Libraries;

namespace RiotGamesApi.Libraries.Converters
{
    public class LongToDateTime : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(long).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddMilliseconds(long.Parse(reader.Value.ToSafetyString()));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((DateTime)value).Ticks);
        }
    }
}