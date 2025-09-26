

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    

    public class EventTimeType
    {
        private EventTimeType(string value) { Value = value; }

        public string Value { get; private set; }
        public static EventTimeType Str { get { return new EventTimeType("str"); } }
        public static EventTimeType Integer { get { return new EventTimeType("integer"); } }
        public static EventTimeType Null { get { return new EventTimeType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(EventTimeType v) { return v.Value; }
        public static EventTimeType FromString(string v) {
            switch(v) {
                case "str": return Str;
                case "integer": return Integer;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for EventTimeType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((EventTimeType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    
/// <summary>
/// The unix epoch timestamp when the event was captured.<br/>
/// 
/// <remarks>
/// 
/// </remarks>
/// </summary>
    [JsonConverter(typeof(EventTime.EventTimeConverter))]
    public class EventTime {
        public EventTime(EventTimeType type) {
            Type = type;
        }
        public string? Str { get; set; } 
        public long? Integer { get; set; } 

        public EventTimeType Type {get; set; }


        public static EventTime CreateStr(string str) {
            EventTimeType typ = EventTimeType.Str;

            EventTime res = new EventTime(typ);
            res.Str = str;
            return res;
        }

        public static EventTime CreateInteger(long integer) {
            EventTimeType typ = EventTimeType.Integer;

            EventTime res = new EventTime(typ);
            res.Integer = integer;
            return res;
        }

        public static EventTime CreateNull() {
            EventTimeType typ = EventTimeType.Null;
            return new EventTime(typ);
        }

        public class EventTimeConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(EventTime);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                }
                if (json[0] == '"' && json[^1] == '"'){
                    return new EventTime(EventTimeType.Str) {
                        Str = json[1..^1]
                    };
                } 
                try {
                    var converted = Convert.ToInt64(json);
                    return new EventTime(EventTimeType.Integer) {
                        Integer = converted
                    };
                } catch (System.FormatException) {
                    // try next option
                }

                throw new InvalidOperationException("Could not deserialize into any supported types.");
            }

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value == null) {
                    writer.WriteRawValue("null");
                    return;
                }
                EventTime res = (EventTime)value;
                if (EventTimeType.FromString(res.Type).Equals(EventTimeType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.Str != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Str, "string"));
                    return;
                }
                if (res.Integer != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Integer));
                    return;
                }

            }
        }

    }

}