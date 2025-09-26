

#nullable enable
namespace fastpix.io.Utils
{
    using System;
    using Newtonsoft.Json;

    internal class DateOnlyConverter: JsonConverter<DateOnly>
    {
        public override DateOnly ReadJson(JsonReader reader, Type objectType, DateOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                throw new ArgumentNullException(nameof(reader.Value));
            }
            return DateOnly.Parse((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}