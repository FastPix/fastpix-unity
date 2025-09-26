

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Pass metric Id<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum ListBreakdownValuesMetricId
    {
        [JsonProperty("views")]
        Views,
        [JsonProperty("unique_viewers")]
        UniqueViewers,
        [JsonProperty("playing_time")]
        PlayingTime,
        [JsonProperty("quality_of_experience_score")]
        QualityOfExperienceScore,
        [JsonProperty("playback_score")]
        PlaybackScore,
        [JsonProperty("playback_failure_percentage")]
        PlaybackFailurePercentage,
        [JsonProperty("exit_before_video_start")]
        ExitBeforeVideoStart,
        [JsonProperty("video_startup_failure_percentage")]
        VideoStartupFailurePercentage,
        [JsonProperty("startup_score")]
        StartupScore,
        [JsonProperty("video_startup_time")]
        VideoStartupTime,
        [JsonProperty("player_startup_time")]
        PlayerStartupTime,
        [JsonProperty("page_load_time")]
        PageLoadTime,
        [JsonProperty("total_startup_time")]
        TotalStartupTime,
        [JsonProperty("live_stream_latency")]
        LiveStreamLatency,
        [JsonProperty("average_bitrate")]
        AverageBitrate,
        [JsonProperty("buffer_count")]
        BufferCount,
        [JsonProperty("render_quality_score")]
        RenderQualityScore,
        [JsonProperty("avg_upscaling")]
        AvgUpscaling,
        [JsonProperty("avg_downscaling")]
        AvgDownscaling,
        [JsonProperty("max_upscaling")]
        MaxUpscaling,
        [JsonProperty("max_downscaling")]
        MaxDownscaling,
        [JsonProperty("jump_latency")]
        JumpLatency,
        [JsonProperty("stability_score")]
        StabilityScore,
        [JsonProperty("buffer_ratio")]
        BufferRatio,
        [JsonProperty("buffer_frequency")]
        BufferFrequency,
        [JsonProperty("buffer_fill")]
        BufferFill,
    }

    public static class ListBreakdownValuesMetricIdExtension
    {
        public static string Value(this ListBreakdownValuesMetricId value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static ListBreakdownValuesMetricId ToEnum(this string value)
        {
            foreach(var field in typeof(ListBreakdownValuesMetricId).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (ListBreakdownValuesMetricId)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum ListBreakdownValuesMetricId");
        }
    }

}