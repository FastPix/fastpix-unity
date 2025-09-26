

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Type of overlay (currently only supports &apos;audio&apos;).
    /// </summary>
    public enum AudioInputType
    {
        [JsonProperty("audio")]
        Audio,
    }

    public static class AudioInputTypeExtension
    {
        public static string Value(this AudioInputType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static AudioInputType ToEnum(this string value)
        {
            foreach(var field in typeof(AudioInputType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (AudioInputType)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum AudioInputType");
        }
    }

}