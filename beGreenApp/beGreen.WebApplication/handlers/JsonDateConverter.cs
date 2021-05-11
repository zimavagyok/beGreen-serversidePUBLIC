using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beGreen.WebApplication.handlers
{
    public class JsonDateConverter : JsonConverter
    {
        const string DATE_VALUE_PREFIX = "JsonDateHandling";

        public override bool CanConvert(Type objectType) => objectType == typeof(DateTime);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => reader.Value == null ? DateTime.MinValue : (DateTime)reader.Value;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(DATE_VALUE_PREFIX + value.ToString());
            writer.Flush();
        }
    }
}
