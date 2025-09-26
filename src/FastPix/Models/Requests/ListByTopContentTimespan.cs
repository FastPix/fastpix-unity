

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// This parameter specifies the time span between which the video views list should be retrieved by. You can provide either from and to unix epoch timestamps or time duration. The scope of duration is between 60 minutes to 30 days.<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum ListByTopContentTimespan
    {
        [JsonProperty("60:minutes")]
        Sixtyminutes,
        [JsonProperty("6:hours")]
        Sixhours,
        [JsonProperty("24:hours")]
        TwentyFourhours,
        [JsonProperty("3:days")]
        Threedays,
        [JsonProperty("7:days")]
        Sevendays,
        [JsonProperty("30:days")]
        Thirtydays,
    }

    public static class ListByTopContentTimespanExtension
    {
        public static string Value(this ListByTopContentTimespan value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static ListByTopContentTimespan ToEnum(this string value)
        {
            foreach(var field in typeof(ListByTopContentTimespan).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (ListByTopContentTimespan)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum ListByTopContentTimespan");
        }
    }

}