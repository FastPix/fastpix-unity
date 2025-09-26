

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Basic access policy for media content
    /// </summary>
    public enum BasicAccessPolicy
    {
        [JsonProperty("public")]
        Public,
        [JsonProperty("private")]
        Private,
    }

    public static class BasicAccessPolicyExtension
    {
        public static string Value(this BasicAccessPolicy value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static BasicAccessPolicy ToEnum(this string value)
        {
            foreach(var field in typeof(BasicAccessPolicy).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (BasicAccessPolicy)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum BasicAccessPolicy");
        }
    }

}