

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The type of media track.
    /// </summary>
    public enum MediaClipResponseType
    {
        [JsonProperty("video")]
        Video,
        [JsonProperty("audio")]
        Audio,
        [JsonProperty("subtitle")]
        Subtitle,
    }

    public static class MediaClipResponseTypeExtension
    {
        public static string Value(this MediaClipResponseType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static MediaClipResponseType ToEnum(this string value)
        {
            foreach(var field in typeof(MediaClipResponseType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (MediaClipResponseType)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum MediaClipResponseType");
        }
    }

}