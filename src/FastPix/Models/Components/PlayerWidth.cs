

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Numerics;
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    

    public class PlayerWidthType
    {
        private PlayerWidthType(string value) { Value = value; }

        public string Value { get; private set; }
        public static PlayerWidthType Str { get { return new PlayerWidthType("str"); } }
        public static PlayerWidthType Number { get { return new PlayerWidthType("number"); } }
        public static PlayerWidthType Null { get { return new PlayerWidthType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(PlayerWidthType v) { return v.Value; }
        public static PlayerWidthType FromString(string v) {
            switch(v) {
                case "str": return Str;
                case "number": return Number;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for PlayerWidthType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((PlayerWidthType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    
/// <summary>
/// Player Width refers to the width of the player displayed within the webpage, measured in pixels.<br/>
/// 
/// <remarks>
/// 
/// </remarks>
/// </summary>
    [JsonConverter(typeof(PlayerWidth.PlayerWidthConverter))]
    public class PlayerWidth {
        public PlayerWidth(PlayerWidthType type) {
            Type = type;
        }
        public string? Str { get; set; } 
        public double? Number { get; set; } 

        public PlayerWidthType Type {get; set; }


        public static PlayerWidth CreateStr(string str) {
            PlayerWidthType typ = PlayerWidthType.Str;

            PlayerWidth res = new PlayerWidth(typ);
            res.Str = str;
            return res;
        }

        public static PlayerWidth CreateNumber(double number) {
            PlayerWidthType typ = PlayerWidthType.Number;

            PlayerWidth res = new PlayerWidth(typ);
            res.Number = number;
            return res;
        }

        public static PlayerWidth CreateNull() {
            PlayerWidthType typ = PlayerWidthType.Null;
            return new PlayerWidth(typ);
        }

        public class PlayerWidthConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(PlayerWidth);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            { 
                var json = JRaw.Create(reader).ToString();

                if (json == "null") {
                    return null;
                }
                if (json[0] == '"' && json[json.Length - 1] == '"'){
                    return new PlayerWidth(PlayerWidthType.Str) {
                        Str = json.Substring(1, json.Length - 2)
                    };
                } 
                try {
                    var converted = Convert.ToDouble(json);
                    return new PlayerWidth(PlayerWidthType.Number) {
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
                PlayerWidth res = (PlayerWidth)value;
                if (PlayerWidthType.FromString(res.Type).Equals(PlayerWidthType.Null))
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