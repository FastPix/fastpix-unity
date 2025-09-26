

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Type will be either smart or manual, as sent in the request body.
    /// </summary>
    public enum PlaylistCreatedSchemaType
    {
        [JsonProperty("smart")]
        Smart,
        [JsonProperty("manual")]
        Manual,
    }

    public static class PlaylistCreatedSchemaTypeExtension
    {
        public static string Value(this PlaylistCreatedSchemaType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static PlaylistCreatedSchemaType ToEnum(this string value)
        {
            foreach(var field in typeof(PlaylistCreatedSchemaType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (PlaylistCreatedSchemaType)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum PlaylistCreatedSchemaType");
        }
    }

}