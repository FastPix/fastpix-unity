

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Language codes are concise, standardized symbols that denote languages, utilizing either two or three characters for identification. The language code must be compliant with the BCP 47 standard to ensure compatibility. (for text only).<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum CreateMediaRequestLanguageCode
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

    public static class CreateMediaRequestLanguageCodeExtension
    {
        public static string Value(this CreateMediaRequestLanguageCode value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static CreateMediaRequestLanguageCode ToEnum(this string value)
        {
            foreach(var field in typeof(CreateMediaRequestLanguageCode).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (CreateMediaRequestLanguageCode)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum CreateMediaRequestLanguageCode");
        }
    }

}