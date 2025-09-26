

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Language codes (BCP 47 compliant) used for text files.<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum LanguageCode
    {
        [JsonProperty("en")]
        En,
        [JsonProperty("it")]
        It,
        [JsonProperty("pl")]
        Pl,
        [JsonProperty("es")]
        Es,
        [JsonProperty("fr")]
        Fr,
        [JsonProperty("ru")]
        Ru,
        [JsonProperty("nl")]
        Nl,
    }

    public static class LanguageCodeExtension
    {
        public static string Value(this LanguageCode value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static LanguageCode ToEnum(this string value)
        {
            foreach(var field in typeof(LanguageCode).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (LanguageCode)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum LanguageCode");
        }
    }

}