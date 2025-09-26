

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    

    public class UniqueViewersEffectedPercentageType
    {
        private UniqueViewersEffectedPercentageType(string value) { Value = value; }

        public string Value { get; private set; }
        public static UniqueViewersEffectedPercentageType Integer { get { return new UniqueViewersEffectedPercentageType("integer"); } }
        public static UniqueViewersEffectedPercentageType Number { get { return new UniqueViewersEffectedPercentageType("number"); } }
        public static UniqueViewersEffectedPercentageType Null { get { return new UniqueViewersEffectedPercentageType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(UniqueViewersEffectedPercentageType v) { return v.Value; }
        public static UniqueViewersEffectedPercentageType FromString(string v) {
            switch(v) {
                case "integer": return Integer;
                case "number": return Number;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for UniqueViewersEffectedPercentageType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((UniqueViewersEffectedPercentageType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    
/// <summary>
/// percentage of unique viewers affected by the specific error.
/// </summary>
    [JsonConverter(typeof(UniqueViewersEffectedPercentage.UniqueViewersEffectedPercentageConverter))]
    public class UniqueViewersEffectedPercentage {
        public UniqueViewersEffectedPercentage(UniqueViewersEffectedPercentageType type) {
            Type = type;
        }
        public long? Integer { get; set; } 
        public double? Number { get; set; } 

        public UniqueViewersEffectedPercentageType Type {get; set; }


        public static UniqueViewersEffectedPercentage CreateInteger(long integer) {
            UniqueViewersEffectedPercentageType typ = UniqueViewersEffectedPercentageType.Integer;

            UniqueViewersEffectedPercentage res = new UniqueViewersEffectedPercentage(typ);
            res.Integer = integer;
            return res;
        }

        public static UniqueViewersEffectedPercentage CreateNumber(double number) {
            UniqueViewersEffectedPercentageType typ = UniqueViewersEffectedPercentageType.Number;

            UniqueViewersEffectedPercentage res = new UniqueViewersEffectedPercentage(typ);
            res.Number = number;
            return res;
        }

        public static UniqueViewersEffectedPercentage CreateNull() {
            UniqueViewersEffectedPercentageType typ = UniqueViewersEffectedPercentageType.Null;
            return new UniqueViewersEffectedPercentage(typ);
        }

        public class UniqueViewersEffectedPercentageConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(UniqueViewersEffectedPercentage);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                } 
                try {
                    var converted = Convert.ToInt64(json);
                    return new UniqueViewersEffectedPercentage(UniqueViewersEffectedPercentageType.Integer) {
                        Integer = converted
                    };
                } catch (System.FormatException) {
                    // try next option
                } 
                try {
                    var converted = Convert.ToDouble(json);
                    return new UniqueViewersEffectedPercentage(UniqueViewersEffectedPercentageType.Number) {
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
                UniqueViewersEffectedPercentage res = (UniqueViewersEffectedPercentage)value;
                if (UniqueViewersEffectedPercentageType.FromString(res.Type).Equals(UniqueViewersEffectedPercentageType.Null))
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