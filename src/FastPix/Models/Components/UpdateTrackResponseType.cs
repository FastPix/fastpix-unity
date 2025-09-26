

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Specifies the type of track (audio or subtitle).
    /// </summary>
    public enum UpdateTrackResponseType
    {
        [JsonProperty("audio")]
        Audio,
        [JsonProperty("subtitle")]
        Subtitle,
    }

    public static class UpdateTrackResponseTypeExtension
    {
        public static string Value(this UpdateTrackResponseType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static UpdateTrackResponseType ToEnum(this string value)
        {
            foreach(var field in typeof(UpdateTrackResponseType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (UpdateTrackResponseType)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum UpdateTrackResponseType");
        }
    }

}