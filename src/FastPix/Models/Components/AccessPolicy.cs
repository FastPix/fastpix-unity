

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Access policy for media content
    /// </summary>
    public enum AccessPolicy
    {
        [JsonProperty("public")]
        Public,
        [JsonProperty("private")]
        Private,
        [JsonProperty("drm")]
        Drm,
    }

    public static class AccessPolicyExtension
    {
        public static string Value(this AccessPolicy value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static AccessPolicy ToEnum(this string value)
        {
            foreach(var field in typeof(AccessPolicy).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (AccessPolicy)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum AccessPolicy");
        }
    }

}