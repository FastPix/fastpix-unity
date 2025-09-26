

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    

    public class TopErrorDetailsPercentageType
    {
        private TopErrorDetailsPercentageType(string value) { Value = value; }

        public string Value { get; private set; }
        public static TopErrorDetailsPercentageType Integer { get { return new TopErrorDetailsPercentageType("integer"); } }
        public static TopErrorDetailsPercentageType Number { get { return new TopErrorDetailsPercentageType("number"); } }
        public static TopErrorDetailsPercentageType Null { get { return new TopErrorDetailsPercentageType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(TopErrorDetailsPercentageType v) { return v.Value; }
        public static TopErrorDetailsPercentageType FromString(string v) {
            switch(v) {
                case "integer": return Integer;
                case "number": return Number;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for TopErrorDetailsPercentageType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((TopErrorDetailsPercentageType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    
/// <summary>
/// views affected by the specific errors.
/// </summary>
    [JsonConverter(typeof(TopErrorDetailsPercentage.TopErrorDetailsPercentageConverter))]
    public class TopErrorDetailsPercentage {
        public TopErrorDetailsPercentage(TopErrorDetailsPercentageType type) {
            Type = type;
        }
        public long? Integer { get; set; } 
        public double? Number { get; set; } 

        public TopErrorDetailsPercentageType Type {get; set; }


        public static TopErrorDetailsPercentage CreateInteger(long integer) {
            TopErrorDetailsPercentageType typ = TopErrorDetailsPercentageType.Integer;

            TopErrorDetailsPercentage res = new TopErrorDetailsPercentage(typ);
            res.Integer = integer;
            return res;
        }

        public static TopErrorDetailsPercentage CreateNumber(double number) {
            TopErrorDetailsPercentageType typ = TopErrorDetailsPercentageType.Number;

            TopErrorDetailsPercentage res = new TopErrorDetailsPercentage(typ);
            res.Number = number;
            return res;
        }

        public static TopErrorDetailsPercentage CreateNull() {
            TopErrorDetailsPercentageType typ = TopErrorDetailsPercentageType.Null;
            return new TopErrorDetailsPercentage(typ);
        }

        public class TopErrorDetailsPercentageConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(TopErrorDetailsPercentage);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                } 
                try {
                    var converted = Convert.ToInt64(json);
                    return new TopErrorDetailsPercentage(TopErrorDetailsPercentageType.Integer) {
                        Integer = converted
                    };
                } catch (System.FormatException) {
                    // try next option
                } 
                try {
                    var converted = Convert.ToDouble(json);
                    return new TopErrorDetailsPercentage(TopErrorDetailsPercentageType.Number) {
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
                TopErrorDetailsPercentage res = (TopErrorDetailsPercentage)value;
                if (TopErrorDetailsPercentageType.FromString(res.Type).Equals(TopErrorDetailsPercentageType.Null))
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