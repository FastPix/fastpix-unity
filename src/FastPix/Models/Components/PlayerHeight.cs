

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    

    public class PlayerHeightType
    {
        private PlayerHeightType(string value) { Value = value; }

        public string Value { get; private set; }
        public static PlayerHeightType Str { get { return new PlayerHeightType("str"); } }
        public static PlayerHeightType Number { get { return new PlayerHeightType("number"); } }
        public static PlayerHeightType Null { get { return new PlayerHeightType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(PlayerHeightType v) { return v.Value; }
        public static PlayerHeightType FromString(string v) {
            switch(v) {
                case "str": return Str;
                case "number": return Number;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for PlayerHeightType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((PlayerHeightType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    
/// <summary>
/// Player Height refers to the vertical dimension, measured in pixels, of the video player as it appears on the webpage.<br/>
/// 
/// <remarks>
/// 
/// </remarks>
/// </summary>
    [JsonConverter(typeof(PlayerHeight.PlayerHeightConverter))]
    public class PlayerHeight {
        public PlayerHeight(PlayerHeightType type) {
            Type = type;
        }
        public string? Str { get; set; } 
        public double? Number { get; set; } 

        public PlayerHeightType Type {get; set; }


        public static PlayerHeight CreateStr(string str) {
            PlayerHeightType typ = PlayerHeightType.Str;

            PlayerHeight res = new PlayerHeight(typ);
            res.Str = str;
            return res;
        }

        public static PlayerHeight CreateNumber(double number) {
            PlayerHeightType typ = PlayerHeightType.Number;

            PlayerHeight res = new PlayerHeight(typ);
            res.Number = number;
            return res;
        }

        public static PlayerHeight CreateNull() {
            PlayerHeightType typ = PlayerHeightType.Null;
            return new PlayerHeight(typ);
        }

        public class PlayerHeightConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(PlayerHeight);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                }
                if (json[0] == '"' && json[^1] == '"'){
                    return new PlayerHeight(PlayerHeightType.Str) {
                        Str = json[1..^1]
                    };
                } 
                try {
                    var converted = Convert.ToDouble(json);
                    return new PlayerHeight(PlayerHeightType.Number) {
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
                PlayerHeight res = (PlayerHeight)value;
                if (PlayerHeightType.FromString(res.Type).Equals(PlayerHeightType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.Str != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Str));
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