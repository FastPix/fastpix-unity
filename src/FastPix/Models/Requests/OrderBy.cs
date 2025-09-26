

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The list of value can be order in two ways DESC (Descending) or ASC (Ascending). In case not specified, by default it will be DESC.
    /// </summary>
    public enum OrderBy
    {
        [JsonProperty("asc")]
        Asc,
        [JsonProperty("desc")]
        Desc,
    }

    public static class OrderByExtension
    {
        public static string Value(this OrderBy value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static OrderBy ToEnum(this string value)
        {
            foreach(var field in typeof(OrderBy).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (OrderBy)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum OrderBy");
        }
    }

}