

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// For a smart playlist metadata is required.
    /// </summary>
    public enum CreatePlaylistRequestType
    {
        [JsonProperty("smart")]
        Smart,
        [JsonProperty("manual")]
        Manual,
    }

    public static class CreatePlaylistRequestTypeExtension
    {
        public static string Value(this CreatePlaylistRequestType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static CreatePlaylistRequestType ToEnum(this string value)
        {
            foreach(var field in typeof(CreatePlaylistRequestType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (CreatePlaylistRequestType)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum CreatePlaylistRequestType");
        }
    }

}