

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
    public enum GetTimeseriesDataSortOrder
    {
        [JsonProperty("asc")]
        Asc,
        [JsonProperty("desc")]
        Desc,
    }

    public static class GetTimeseriesDataSortOrderExtension
    {
        public static string Value(this GetTimeseriesDataSortOrder value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static GetTimeseriesDataSortOrder ToEnum(this string value)
        {
            foreach(var field in typeof(GetTimeseriesDataSortOrder).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (GetTimeseriesDataSortOrder)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum GetTimeseriesDataSortOrder");
        }
    }

}