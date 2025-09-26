

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The values in the list can be arranged in two ways: DESC (Descending) or ASC (Ascending).
    /// </summary>
    public enum SortOrder
    {
        [JsonProperty("asc")]
        Asc,
        [JsonProperty("desc")]
        Desc,
    }

    public static class SortOrderExtension
    {
        public static string Value(this SortOrder value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static SortOrder ToEnum(this string value)
        {
            foreach(var field in typeof(SortOrder).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (SortOrder)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum SortOrder");
        }
    }

}