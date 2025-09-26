

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    

    public class GlobalValueType
    {
        private GlobalValueType(string value) { Value = value; }

        public string Value { get; private set; }
        public static GlobalValueType Integer { get { return new GlobalValueType("integer"); } }
        public static GlobalValueType Number { get { return new GlobalValueType("number"); } }
        public static GlobalValueType Null { get { return new GlobalValueType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(GlobalValueType v) { return v.Value; }
        public static GlobalValueType FromString(string v) {
            switch(v) {
                case "integer": return Integer;
                case "number": return Number;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for GlobalValueType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((GlobalValueType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    
/// <summary>
/// A global metric value that reflects the overall performance of the specified metric across the entire dataset for the given timespan.
/// </summary>
    [JsonConverter(typeof(GlobalValue.GlobalValueConverter))]
    public class GlobalValue {
        public GlobalValue(GlobalValueType type) {
            Type = type;
        }
        public long? Integer { get; set; } 
        public double? Number { get; set; } 

        public GlobalValueType Type {get; set; }


        public static GlobalValue CreateInteger(long integer) {
            GlobalValueType typ = GlobalValueType.Integer;

            GlobalValue res = new GlobalValue(typ);
            res.Integer = integer;
            return res;
        }

        public static GlobalValue CreateNumber(double number) {
            GlobalValueType typ = GlobalValueType.Number;

            GlobalValue res = new GlobalValue(typ);
            res.Number = number;
            return res;
        }

        public static GlobalValue CreateNull() {
            GlobalValueType typ = GlobalValueType.Null;
            return new GlobalValue(typ);
        }

        public class GlobalValueConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(GlobalValue);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                } 
                try {
                    var converted = Convert.ToInt64(json);
                    return new GlobalValue(GlobalValueType.Integer) {
                        Integer = converted
                    };
                } catch (System.FormatException) {
                    // try next option
                } 
                try {
                    var converted = Convert.ToDouble(json);
                    return new GlobalValue(GlobalValueType.Number) {
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
                GlobalValue res = (GlobalValue)value;
                if (GlobalValueType.FromString(res.Type).Equals(GlobalValueType.Null))
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