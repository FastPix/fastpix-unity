

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Horizontal alignment of the watermark.
    /// </summary>
    public enum XAlign
    {
        [JsonProperty("left")]
        Left,
        [JsonProperty("center")]
        Center,
        [JsonProperty("right")]
        Right,
    }

    public static class XAlignExtension
    {
        public static string Value(this XAlign value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static XAlign ToEnum(this string value)
        {
            foreach(var field in typeof(XAlign).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (XAlign)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum XAlign");
        }
    }

}