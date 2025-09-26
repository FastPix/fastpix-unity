

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    public enum PlaylistItemType
    {
        [JsonProperty("manual")]
        Manual,
        [JsonProperty("smart")]
        Smart,
    }

    public static class PlaylistItemTypeExtension
    {
        public static string Value(this PlaylistItemType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static PlaylistItemType ToEnum(this string value)
        {
            foreach(var field in typeof(PlaylistItemType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (PlaylistItemType)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum PlaylistItemType");
        }
    }

}