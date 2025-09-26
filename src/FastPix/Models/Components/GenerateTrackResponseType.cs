

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The type of track generated (&quot;subtitle&quot;).
    /// </summary>
    public enum GenerateTrackResponseType
    {
        [JsonProperty("subtitle")]
        Subtitle,
    }

    public static class GenerateTrackResponseTypeExtension
    {
        public static string Value(this GenerateTrackResponseType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static GenerateTrackResponseType ToEnum(this string value)
        {
            foreach(var field in typeof(GenerateTrackResponseType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (GenerateTrackResponseType)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum GenerateTrackResponseType");
        }
    }

}