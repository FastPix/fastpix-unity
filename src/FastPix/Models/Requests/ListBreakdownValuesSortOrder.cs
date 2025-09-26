

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The order direction to sort the metrics list by.<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum ListBreakdownValuesSortOrder
    {
        [JsonProperty("asc")]
        Asc,
        [JsonProperty("desc")]
        Desc,
    }

    public static class ListBreakdownValuesSortOrderExtension
    {
        public static string Value(this ListBreakdownValuesSortOrder value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static ListBreakdownValuesSortOrder ToEnum(this string value)
        {
            foreach(var field in typeof(ListBreakdownValuesSortOrder).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (ListBreakdownValuesSortOrder)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum ListBreakdownValuesSortOrder");
        }
    }

}