

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The current processing status of the media.
    /// </summary>
    public enum Status
    {
        [JsonProperty("preparing")]
        Preparing,
        [JsonProperty("ready")]
        Ready,
        [JsonProperty("failed")]
        Failed,
        [JsonProperty("created")]
        Created,
    }

    public static class StatusExtension
    {
        public static string Value(this Status value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static Status ToEnum(this string value)
        {
            foreach(var field in typeof(Status).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (Status)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum Status");
        }
    }

}