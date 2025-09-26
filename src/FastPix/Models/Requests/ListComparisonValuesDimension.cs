

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The dimension id in which the views are watched.<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum ListComparisonValuesDimension
    {
        [JsonProperty("browser_name")]
        BrowserName,
        [JsonProperty("browser_version")]
        BrowserVersion,
        [JsonProperty("os_name")]
        OsName,
        [JsonProperty("os_version")]
        OsVersion,
        [JsonProperty("device_name")]
        DeviceName,
        [JsonProperty("device_model")]
        DeviceModel,
        [JsonProperty("device_type")]
        DeviceType,
        [JsonProperty("device_manufacturer")]
        DeviceManufacturer,
        [JsonProperty("player_remote_played")]
        PlayerRemotePlayed,
        [JsonProperty("player_name")]
        PlayerName,
        [JsonProperty("player_version")]
        PlayerVersion,
        [JsonProperty("player_software_name")]
        PlayerSoftwareName,
        [JsonProperty("player_software_version")]
        PlayerSoftwareVersion,
        [JsonProperty("player_resolution")]
        PlayerResolution,
        [JsonProperty("fp_sdk")]
        FpSDK,
        [JsonProperty("fp_sdk_version")]
        FpSDKVersion,
        [JsonProperty("player_autoplay_on")]
        PlayerAutoplayOn,
        [JsonProperty("player_preload_on")]
        PlayerPreloadOn,
        [JsonProperty("video_title")]
        VideoTitle,
        [JsonProperty("video_id")]
        VideoId,
        [JsonProperty("video_series")]
        VideoSeries,
        [JsonProperty("fp_playback_id")]
        FpPlaybackId,
        [JsonProperty("fp_live_stream_id")]
        FpLiveStreamId,
        [JsonProperty("media_id")]
        MediaId,
        [JsonProperty("video_source_stream_type")]
        VideoSourceStreamType,
        [JsonProperty("video_source_type")]
        VideoSourceType,
        [JsonProperty("video_encoding_variant")]
        VideoEncodingVariant,
        [JsonProperty("experiment_name")]
        ExperimentName,
        [JsonProperty("sub_property_id")]
        SubPropertyId,
        [JsonProperty("drm_type")]
        DrmType,
        [JsonProperty("asn_name")]
        AsnName,
        [JsonProperty("cdn")]
        Cdn,
        [JsonProperty("video_source_hostname")]
        VideoSourceHostname,
        [JsonProperty("connection_type")]
        ConnectionType,
        [JsonProperty("view_session_id")]
        ViewSessionId,
        [JsonProperty("continent")]
        Continent,
        [JsonProperty("country")]
        Country,
        [JsonProperty("region")]
        Region,
        [JsonProperty("viewer_id")]
        ViewerId,
        [JsonProperty("error_code")]
        ErrorCode,
        [JsonProperty("exit_before_video_start")]
        ExitBeforeVideoStart,
        [JsonProperty("view_has_ad")]
        ViewHasAd,
        [JsonProperty("video_startup_failed")]
        VideoStartupFailed,
        [JsonProperty("page_context")]
        PageContext,
        [JsonProperty("playback_failed")]
        PlaybackFailed,
        [JsonProperty("custom_1")]
        Custom1,
        [JsonProperty("custom_2")]
        Custom2,
        [JsonProperty("custom_3")]
        Custom3,
        [JsonProperty("custom_4")]
        Custom4,
        [JsonProperty("custom_5")]
        Custom5,
        [JsonProperty("custom_6")]
        Custom6,
        [JsonProperty("custom_7")]
        Custom7,
        [JsonProperty("custom_8")]
        Custom8,
        [JsonProperty("custom_9")]
        Custom9,
        [JsonProperty("custom_10")]
        Custom10,
    }

    public static class ListComparisonValuesDimensionExtension
    {
        public static string Value(this ListComparisonValuesDimension value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static ListComparisonValuesDimension ToEnum(this string value)
        {
            foreach(var field in typeof(ListComparisonValuesDimension).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    return (ListComparisonValuesDimension)field.GetValue(null);
                }
            }

            throw new Exception($"Unknown value {value} for enum ListComparisonValuesDimension");
        }
    }

}