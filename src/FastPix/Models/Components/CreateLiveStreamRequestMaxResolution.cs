

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Max resolution can be used to control the maximum resolution your media is encoded, stored, and streamed at.
    /// </summary>
    public enum CreateLiveStreamRequestMaxResolution
    {
        [JsonProperty("1080p")]
        OneThousandAndEightyp,
        [JsonProperty("720p")]
        SevenHundredAndTwentyp,
        [JsonProperty("480p")]
        FourHundredAndEightyp,
    }

    public static class CreateLiveStreamRequestMaxResolutionExtension
    {
        public static string Value(this CreateLiveStreamRequestMaxResolution value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static CreateLiveStreamRequestMaxResolution ToEnum(this string value)
        {
            foreach(var field in typeof(CreateLiveStreamRequestMaxResolution).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (CreateLiveStreamRequestMaxResolution)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum CreateLiveStreamRequestMaxResolution");
        }
    }

}