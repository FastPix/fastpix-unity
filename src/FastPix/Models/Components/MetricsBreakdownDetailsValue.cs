

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    

    public class MetricsBreakdownDetailsValueType
    {
        private MetricsBreakdownDetailsValueType(string value) { Value = value; }

        public string Value { get; private set; }
        public static MetricsBreakdownDetailsValueType Integer { get { return new MetricsBreakdownDetailsValueType("integer"); } }
        public static MetricsBreakdownDetailsValueType Number { get { return new MetricsBreakdownDetailsValueType("number"); } }
        public static MetricsBreakdownDetailsValueType Null { get { return new MetricsBreakdownDetailsValueType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(MetricsBreakdownDetailsValueType v) { return v.Value; }
        public static MetricsBreakdownDetailsValueType FromString(string v) {
            switch(v) {
                case "integer": return Integer;
                case "number": return Number;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for MetricsBreakdownDetailsValueType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((MetricsBreakdownDetailsValueType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    
/// <summary>
/// The specific metric value calculated based on the applied filters.
/// </summary>
    [JsonConverter(typeof(MetricsBreakdownDetailsValue.MetricsBreakdownDetailsValueConverter))]
    public class MetricsBreakdownDetailsValue {
        public MetricsBreakdownDetailsValue(MetricsBreakdownDetailsValueType type) {
            Type = type;
        }
        public long? Integer { get; set; } 
        public double? Number { get; set; } 

        public MetricsBreakdownDetailsValueType Type {get; set; }


        public static MetricsBreakdownDetailsValue CreateInteger(long integer) {
            MetricsBreakdownDetailsValueType typ = MetricsBreakdownDetailsValueType.Integer;

            MetricsBreakdownDetailsValue res = new MetricsBreakdownDetailsValue(typ);
            res.Integer = integer;
            return res;
        }

        public static MetricsBreakdownDetailsValue CreateNumber(double number) {
            MetricsBreakdownDetailsValueType typ = MetricsBreakdownDetailsValueType.Number;

            MetricsBreakdownDetailsValue res = new MetricsBreakdownDetailsValue(typ);
            res.Number = number;
            return res;
        }

        public static MetricsBreakdownDetailsValue CreateNull() {
            MetricsBreakdownDetailsValueType typ = MetricsBreakdownDetailsValueType.Null;
            return new MetricsBreakdownDetailsValue(typ);
        }

        public class MetricsBreakdownDetailsValueConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(MetricsBreakdownDetailsValue);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                } 
                try {
                    var converted = Convert.ToInt64(json);
                    return new MetricsBreakdownDetailsValue(MetricsBreakdownDetailsValueType.Integer) {
                        Integer = converted
                    };
                } catch (System.FormatException) {
                    // try next option
                } 
                try {
                    var converted = Convert.ToDouble(json);
                    return new MetricsBreakdownDetailsValue(MetricsBreakdownDetailsValueType.Number) {
                        Number = converted
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
                MetricsBreakdownDetailsValue res = (MetricsBreakdownDetailsValue)value;
                if (MetricsBreakdownDetailsValueType.FromString(res.Type).Equals(MetricsBreakdownDetailsValueType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.Integer != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Integer));
                    return;
                }
                if (res.Number != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Number));
                    return;
                }

            }
        }

    }

}