

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    

    public class MetricValueType
    {
        private MetricValueType(string value) { Value = value; }

        public string Value { get; private set; }
        public static MetricValueType Integer { get { return new MetricValueType("integer"); } }
        public static MetricValueType Number { get { return new MetricValueType("number"); } }
        public static MetricValueType Null { get { return new MetricValueType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(MetricValueType v) { return v.Value; }
        public static MetricValueType FromString(string v) {
            switch(v) {
                case "integer": return Integer;
                case "number": return Number;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for MetricValueType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((MetricValueType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    
/// <summary>
/// The value of the specified metric at the given interval.
/// </summary>
    [JsonConverter(typeof(MetricValue.MetricValueConverter))]
    public class MetricValue {
        public MetricValue(MetricValueType type) {
            Type = type;
        }
        public long? Integer { get; set; } 
        public double? Number { get; set; } 

        public MetricValueType Type {get; set; }


        public static MetricValue CreateInteger(long integer) {
            MetricValueType typ = MetricValueType.Integer;

            MetricValue res = new MetricValue(typ);
            res.Integer = integer;
            return res;
        }

        public static MetricValue CreateNumber(double number) {
            MetricValueType typ = MetricValueType.Number;

            MetricValue res = new MetricValue(typ);
            res.Number = number;
            return res;
        }

        public static MetricValue CreateNull() {
            MetricValueType typ = MetricValueType.Null;
            return new MetricValue(typ);
        }

        public class MetricValueConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(MetricValue);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                } 
                try {
                    var converted = Convert.ToInt64(json);
                    return new MetricValue(MetricValueType.Integer) {
                        Integer = converted
                    };
                } catch (System.FormatException) {
                    // try next option
                } 
                try {
                    var converted = Convert.ToDouble(json);
                    return new MetricValue(MetricValueType.Number) {
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
                MetricValue res = (MetricValue)value;
                if (MetricValueType.FromString(res.Type).Equals(MetricValueType.Null))
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