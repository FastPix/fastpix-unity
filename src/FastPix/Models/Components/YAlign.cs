

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Vertical alignment of the watermark.
    /// </summary>
    public enum YAlign
    {
        [JsonProperty("top")]
        Top,
        [JsonProperty("middle")]
        Middle,
        [JsonProperty("bottom")]
        Bottom,
    }

    public static class YAlignExtension
    {
        public static string Value(this YAlign value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static YAlign ToEnum(this string value)
        {
            foreach(var field in typeof(YAlign).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (YAlign)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum YAlign");
        }
    }

}