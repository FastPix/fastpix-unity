

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Type of media content
    /// </summary>
    public enum MediaType
    {
        [JsonProperty("video")]
        Video,
        [JsonProperty("audio")]
        Audio,
        [JsonProperty("av")]
        Av,
    }

    public static class MediaTypeExtension
    {
        public static string Value(this MediaType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static MediaType ToEnum(this string value)
        {
            foreach(var field in typeof(MediaType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (MediaType)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum MediaType");
        }
    }

}