

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Generates MP4 video up to 4K (&quot;capped_4k&quot;), m4a audio only (&quot;audioOnly&quot;), or both for offline viewing.<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum DirectUploadVideoMediaMp4Support
    {
        [JsonProperty("capped_4k")]
        Capped4k,
        [JsonProperty("audioOnly")]
        AudioOnly,
        [JsonProperty("audioOnly,capped_4k")]
        AudioOnlyCapped4k,
    }

    public static class DirectUploadVideoMediaMp4SupportExtension
    {
        public static string Value(this DirectUploadVideoMediaMp4Support value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static DirectUploadVideoMediaMp4Support ToEnum(this string value)
        {
            foreach(var field in typeof(DirectUploadVideoMediaMp4Support).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (DirectUploadVideoMediaMp4Support)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum DirectUploadVideoMediaMp4Support");
        }
    }

}