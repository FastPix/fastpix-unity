

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// type of the playlist, when it was created
    /// </summary>
    public enum PlaylistByIdResponseType
    {
        [JsonProperty("manual")]
        Manual,
        [JsonProperty("smart")]
        Smart,
    }

    public static class PlaylistByIdResponseTypeExtension
    {
        public static string Value(this PlaylistByIdResponseType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static PlaylistByIdResponseType ToEnum(this string value)
        {
            foreach(var field in typeof(PlaylistByIdResponseType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (PlaylistByIdResponseType)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum PlaylistByIdResponseType");
        }
    }

}