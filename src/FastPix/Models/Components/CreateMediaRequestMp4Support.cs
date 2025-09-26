

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// &quot;capped_4k&quot;: Generates an mp4 video file up to 4k resolution &quot;audioOnly&quot;: Generates an m4a audio file of the media file &quot;audioOnly,capped_4k&quot;: Generates both video and audio media files for offline viewing<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum CreateMediaRequestMp4Support
    {
        [JsonProperty("capped_4k")]
        Capped4k,
        [JsonProperty("audioOnly")]
        AudioOnly,
        [JsonProperty("audioOnly,capped_4k")]
        AudioOnlyCapped4k,
    }

    public static class CreateMediaRequestMp4SupportExtension
    {
        public static string Value(this CreateMediaRequestMp4Support value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static CreateMediaRequestMp4Support ToEnum(this string value)
        {
            foreach(var field in typeof(CreateMediaRequestMp4Support).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (CreateMediaRequestMp4Support)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum CreateMediaRequestMp4Support");
        }
    }

}