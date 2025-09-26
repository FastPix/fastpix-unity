

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Determines the type of MP4 support for the media.   - **none**: Disables MP4 support.   - **capped_4k**: Enables MP4 downloads with resolutions up to 4K.   - **audioOnly**: Provides an MP4 stream containing only the audio.   - **audioOnly,capped_4k**: Enables both MP4 video downloads (up to 4K) and an audio-only stream.  
    /// </summary>
    public enum UpdatedMp4SupportMp4Support
    {
        [JsonProperty("none")]
        None,
        [JsonProperty("capped_4k")]
        Capped4k,
        [JsonProperty("audioOnly")]
        AudioOnly,
        [JsonProperty("audioOnly,capped_4k")]
        AudioOnlyCapped4k,
    }

    public static class UpdatedMp4SupportMp4SupportExtension
    {
        public static string Value(this UpdatedMp4SupportMp4Support value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static UpdatedMp4SupportMp4Support ToEnum(this string value)
        {
            foreach(var field in typeof(UpdatedMp4SupportMp4Support).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (UpdatedMp4SupportMp4Support)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum UpdatedMp4SupportMp4Support");
        }
    }

}