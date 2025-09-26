

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Type of overlay (currently only supports &apos;watermark&apos;).
    /// </summary>
    public enum WatermarkInputType
    {
        [JsonProperty("watermark")]
        Watermark,
    }

    public static class WatermarkInputTypeExtension
    {
        public static string Value(this WatermarkInputType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static WatermarkInputType ToEnum(this string value)
        {
            foreach(var field in typeof(WatermarkInputType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (WatermarkInputType)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum WatermarkInputType");
        }
    }

}