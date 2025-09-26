

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Pass this value to group the metrics list by.<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum GroupBy
    {
        [JsonProperty("minute")]
        Minute,
        [JsonProperty("ten_minutes")]
        TenMinutes,
        [JsonProperty("hour")]
        Hour,
        [JsonProperty("day")]
        Day,
    }

    public static class GroupByExtension
    {
        public static string Value(this GroupBy value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static GroupBy ToEnum(this string value)
        {
            foreach(var field in typeof(GroupBy).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (GroupBy)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum GroupBy");
        }
    }

}