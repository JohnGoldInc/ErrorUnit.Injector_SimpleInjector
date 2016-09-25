using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ErrorUnit.Injector_SimpleInjector
{
    /// <summary>
    /// This handles SipleInjector Proxied Types and Serializing them
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    public class ProxiedTypeSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType is ProxiedType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return JObject.Load(reader)
                          .ToObject(objectType, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            var str = value?.ToString().Trim();
            if (value.GetType().IsArray) {
                writer.WriteStartArray();
                writer.WriteRaw(str.Substring(1,str.Length-2));
                writer.WriteEndArray();
            } else {
                writer.WriteStartObject();
                writer.WriteRaw(str.Substring(1, str.Length - 2));
                writer.WriteEndObject();
            }
        }
    }
}
