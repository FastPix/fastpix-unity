

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    

    public class ErrorDetailsPercentageType
    {
        private ErrorDetailsPercentageType(string value) { Value = value; }

        public string Value { get; private set; }
        public static ErrorDetailsPercentageType Integer { get { return new ErrorDetailsPercentageType("integer"); } }
        public static ErrorDetailsPercentageType Number { get { return new ErrorDetailsPercentageType("number"); } }
        public static ErrorDetailsPercentageType Null { get { return new ErrorDetailsPercentageType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(ErrorDetailsPercentageType v) { return v.Value; }
        public static ErrorDetailsPercentageType FromString(string v) {
            switch(v) {
                case "integer": return Integer;
                case "number": return Number;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for ErrorDetailsPercentageType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((ErrorDetailsPercentageType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    
/// <summary>
/// views affected by the specific errors.
/// </summary>
    [JsonConverter(typeof(ErrorDetailsPercentage.ErrorDetailsPercentageConverter))]
    public class ErrorDetailsPercentage {
        public ErrorDetailsPercentage(ErrorDetailsPercentageType type) {
            Type = type;
        }
        public long? Integer { get; set; } 
        public double? Number { get; set; } 

        public ErrorDetailsPercentageType Type {get; set; }


        public static ErrorDetailsPercentage CreateInteger(long integer) {
            ErrorDetailsPercentageType typ = ErrorDetailsPercentageType.Integer;

            ErrorDetailsPercentage res = new ErrorDetailsPercentage(typ);
            res.Integer = integer;
            return res;
        }

        public static ErrorDetailsPercentage CreateNumber(double number) {
            ErrorDetailsPercentageType typ = ErrorDetailsPercentageType.Number;

            ErrorDetailsPercentage res = new ErrorDetailsPercentage(typ);
            res.Number = number;
            return res;
        }

        public static ErrorDetailsPercentage CreateNull() {
            ErrorDetailsPercentageType typ = ErrorDetailsPercentageType.Null;
            return new ErrorDetailsPercentage(typ);
        }

        public class ErrorDetailsPercentageConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(ErrorDetailsPercentage);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                } 
                try {
                    var converted = Convert.ToInt64(json);
                    return new ErrorDetailsPercentage(ErrorDetailsPercentageType.Integer) {
                        Integer = converted
                    };
                } catch (System.FormatException) {
                    // try next option
                } 
                try {
                    var converted = Convert.ToDouble(json);
                    return new ErrorDetailsPercentage(ErrorDetailsPercentageType.Number) {
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
                ErrorDetailsPercentage res = (ErrorDetailsPercentage)value;
                if (ErrorDetailsPercentageType.FromString(res.Type).Equals(ErrorDetailsPercentageType.Null))
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