

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The maximum resolution for the playback ID.
    /// </summary>
    public enum Resolution
    {
        [JsonProperty("480p")]
        FourHundredAndEightyp,
        [JsonProperty("720p")]
        SevenHundredAndTwentyp,
        [JsonProperty("1080p")]
        OneThousandAndEightyp,
        [JsonProperty("1440p")]
        OneThousandFourHundredAndFortyp,
        [JsonProperty("2160p")]
        TwoThousandOneHundredAndSixtyp,
    }

    public static class ResolutionExtension
    {
        public static string Value(this Resolution value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static Resolution ToEnum(this string value)
        {
            foreach(var field in typeof(Resolution).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (Resolution)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum Resolution");
        }
    }

}