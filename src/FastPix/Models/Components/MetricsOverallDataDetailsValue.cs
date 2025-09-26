

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    

    public class MetricsOverallDataDetailsValueType
    {
        private MetricsOverallDataDetailsValueType(string value) { Value = value; }

        public string Value { get; private set; }
        public static MetricsOverallDataDetailsValueType Integer { get { return new MetricsOverallDataDetailsValueType("integer"); } }
        public static MetricsOverallDataDetailsValueType Number { get { return new MetricsOverallDataDetailsValueType("number"); } }
        public static MetricsOverallDataDetailsValueType Null { get { return new MetricsOverallDataDetailsValueType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(MetricsOverallDataDetailsValueType v) { return v.Value; }
        public static MetricsOverallDataDetailsValueType FromString(string v) {
            switch(v) {
                case "integer": return Integer;
                case "number": return Number;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for MetricsOverallDataDetailsValueType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((MetricsOverallDataDetailsValueType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    
/// <summary>
/// metric value calculated based on the applied filters.
/// </summary>
    [JsonConverter(typeof(MetricsOverallDataDetailsValue.MetricsOverallDataDetailsValueConverter))]
    public class MetricsOverallDataDetailsValue {
        public MetricsOverallDataDetailsValue(MetricsOverallDataDetailsValueType type) {
            Type = type;
        }
        public long? Integer { get; set; } 
        public double? Number { get; set; } 

        public MetricsOverallDataDetailsValueType Type {get; set; }


        public static MetricsOverallDataDetailsValue CreateInteger(long integer) {
            MetricsOverallDataDetailsValueType typ = MetricsOverallDataDetailsValueType.Integer;

            MetricsOverallDataDetailsValue res = new MetricsOverallDataDetailsValue(typ);
            res.Integer = integer;
            return res;
        }

        public static MetricsOverallDataDetailsValue CreateNumber(double number) {
            MetricsOverallDataDetailsValueType typ = MetricsOverallDataDetailsValueType.Number;

            MetricsOverallDataDetailsValue res = new MetricsOverallDataDetailsValue(typ);
            res.Number = number;
            return res;
        }

        public static MetricsOverallDataDetailsValue CreateNull() {
            MetricsOverallDataDetailsValueType typ = MetricsOverallDataDetailsValueType.Null;
            return new MetricsOverallDataDetailsValue(typ);
        }

        public class MetricsOverallDataDetailsValueConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(MetricsOverallDataDetailsValue);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                } 
                try {
                    var converted = Convert.ToInt64(json);
                    return new MetricsOverallDataDetailsValue(MetricsOverallDataDetailsValueType.Integer) {
                        Integer = converted
                    };
                } catch (System.FormatException) {
                    // try next option
                } 
                try {
                    var converted = Convert.ToDouble(json);
                    return new MetricsOverallDataDetailsValue(MetricsOverallDataDetailsValueType.Number) {
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
                MetricsOverallDataDetailsValue res = (MetricsOverallDataDetailsValue)value;
                if (MetricsOverallDataDetailsValueType.FromString(res.Type).Equals(MetricsOverallDataDetailsValueType.Null))
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