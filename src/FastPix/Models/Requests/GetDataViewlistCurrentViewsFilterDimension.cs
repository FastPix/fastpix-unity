

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The dimension to group and breakdown the concurrent viewers data by.<br/>
    /// 
    /// <remarks>
    /// This determines how the results will be categorized and aggregated.<br/>
    /// Choose from geographic, content, technical, or behavioral dimensions.<br/>
    /// 
    /// </remarks>
    /// </summary>
    public enum GetDataViewlistCurrentViewsFilterDimension
    {
        [JsonProperty("country")]
        Country,
        [JsonProperty("region")]
        Region,
        [JsonProperty("asn_id")]
        AsnId,
        [JsonProperty("cdn")]
        Cdn,
        [JsonProperty("video_title")]
        VideoTitle,
        [JsonProperty("video_series")]
        VideoSeries,
        [JsonProperty("video_id")]
        VideoId,
        [JsonProperty("sub_property_id")]
        SubPropertyId,
        [JsonProperty("video_source_stream_type")]
        VideoSourceStreamType,
        [JsonProperty("os_name")]
        OsName,
        [JsonProperty("player_name")]
        PlayerName,
        [JsonProperty("media_id")]
        MediaId,
        [JsonProperty("fp_playback_id")]
        FpPlaybackId,
        [JsonProperty("view_id")]
        ViewId,
    }

    public static class GetDataViewlistCurrentViewsFilterDimensionExtension
    {
        public static string Value(this GetDataViewlistCurrentViewsFilterDimension value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static GetDataViewlistCurrentViewsFilterDimension ToEnum(this string value)
        {
            foreach(var field in typeof(GetDataViewlistCurrentViewsFilterDimension).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (GetDataViewlistCurrentViewsFilterDimension)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum GetDataViewlistCurrentViewsFilterDimension");
        }
    }

}