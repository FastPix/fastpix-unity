

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The maximum resolution tier determines the highest quality your media will be available in.<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum CreateMediaRequestMaxResolution
    {
        [JsonProperty("2160p")]
        TwoThousandOneHundredAndSixtyp,
        [JsonProperty("1440p")]
        OneThousandFourHundredAndFortyp,
        [JsonProperty("1080p")]
        OneThousandAndEightyp,
        [JsonProperty("720p")]
        SevenHundredAndTwentyp,
        [JsonProperty("480p")]
        FourHundredAndEightyp,
        [JsonProperty("360p")]
        ThreeHundredAndSixtyp,
    }

    public static class CreateMediaRequestMaxResolutionExtension
    {
        public static string Value(this CreateMediaRequestMaxResolution value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static CreateMediaRequestMaxResolution ToEnum(this string value)
        {
            foreach(var field in typeof(CreateMediaRequestMaxResolution).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (CreateMediaRequestMaxResolution)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum CreateMediaRequestMaxResolution");
        }
    }

}