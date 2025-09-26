

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Specifies the type of track being added. It can be either `audio` or `subtitle`.
    /// </summary>
    public enum AddTrackRequestType
    {
        [JsonProperty("audio")]
        Audio,
        [JsonProperty("subtitle")]
        Subtitle,
    }

    public static class AddTrackRequestTypeExtension
    {
        public static string Value(this AddTrackRequestType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static AddTrackRequestType ToEnum(this string value)
        {
            foreach(var field in typeof(AddTrackRequestType).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (AddTrackRequestType)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum AddTrackRequestType");
        }
    }

}