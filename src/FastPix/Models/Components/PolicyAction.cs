

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Policy action type
    /// </summary>
    public enum PolicyAction
    {
        [JsonProperty("allow")]
        Allow,
        [JsonProperty("deny")]
        Deny,
    }

    public static class PolicyActionExtension
    {
        public static string Value(this PolicyAction value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static PolicyAction ToEnum(this string value)
        {
            foreach(var field in typeof(PolicyAction).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (PolicyAction)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum PolicyAction");
        }
    }

}