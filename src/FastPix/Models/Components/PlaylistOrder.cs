

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Determines the insertion order of media into playlist.
    /// </summary>
    public enum PlaylistOrder
    {
        [JsonProperty("createdDate ASC")]
        CreatedDateASC,
        [JsonProperty("createdDate DESC")]
        CreatedDateDESC,
    }

    public static class PlaylistOrderExtension
    {
        public static string Value(this PlaylistOrder value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static PlaylistOrder ToEnum(this string value)
        {
            foreach(var field in typeof(PlaylistOrder).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (PlaylistOrder)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum PlaylistOrder");
        }
    }

}