

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    

    public class ErrorCodeType
    {
        private ErrorCodeType(string value) { Value = value; }

        public string Value { get; private set; }
        public static ErrorCodeType Str { get { return new ErrorCodeType("str"); } }
        public static ErrorCodeType Integer { get { return new ErrorCodeType("integer"); } }
        public static ErrorCodeType Null { get { return new ErrorCodeType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(ErrorCodeType v) { return v.Value; }
        public static ErrorCodeType FromString(string v) {
            switch(v) {
                case "str": return Str;
                case "integer": return Integer;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for ErrorCodeType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((ErrorCodeType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    
/// <summary>
/// Pass the error code to filter the list of views. The possible values of error code can be fetched from list of errors end point.<br/>
/// 
/// <remarks>
/// 
/// </remarks>
/// </summary>
    [JsonConverter(typeof(ErrorCode.ErrorCodeConverter))]
    public class ErrorCode {
        public ErrorCode(ErrorCodeType type) {
            Type = type;
        }
        public string? Str { get; set; } 
        public long? Integer { get; set; } 

        public ErrorCodeType Type {get; set; }


        public static ErrorCode CreateStr(string str) {
            ErrorCodeType typ = ErrorCodeType.Str;

            ErrorCode res = new ErrorCode(typ);
            res.Str = str;
            return res;
        }

        public static ErrorCode CreateInteger(long integer) {
            ErrorCodeType typ = ErrorCodeType.Integer;

            ErrorCode res = new ErrorCode(typ);
            res.Integer = integer;
            return res;
        }

        public static ErrorCode CreateNull() {
            ErrorCodeType typ = ErrorCodeType.Null;
            return new ErrorCode(typ);
        }

        public class ErrorCodeConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(ErrorCode);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                }
                if (json[0] == '"' && json[^1] == '"'){
                    return new ErrorCode(ErrorCodeType.Str) {
                        Str = json[1..^1]
                    };
                } 
                try {
                    var converted = Convert.ToInt64(json);
                    return new ErrorCode(ErrorCodeType.Integer) {
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
                ErrorCode res = (ErrorCode)value;
                if (ErrorCodeType.FromString(res.Type).Equals(ErrorCodeType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.Str != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Str));
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