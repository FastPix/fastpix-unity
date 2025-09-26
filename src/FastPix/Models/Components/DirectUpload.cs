

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Displays the result of the request.
    /// </summary>
    [Serializable]
    public class DirectUpload
    {

        /// <summary>
        /// When creating the upload, FastPix assigns a universally unique identifier with a maximum length of 255 characters.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// When creating the media, FastPix assigns a universally unique identifier with a maximum length of 255 characters.
        /// </summary>
        [SerializeField]
        [JsonProperty("mediaId")]
        public string? MediaId { get; set; }

        /// <summary>
        /// Determines the media&apos;s status, which can be one of the possible values.
        /// </summary>
        [SerializeField]
        [JsonProperty("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The url hosts the media file for FastPix, which needs to be download to use further.  It supports formats like MP3, MP4, MOV, MKV, or TS, and includes text tracks for subtitles/CC (SRT file/VTT file). While FastPix can handle various audio and video formats and codecs, using standard inputs can help with optimal processing speed.
        /// </summary>
        [SerializeField]
        [JsonProperty("url")]
        public string? Url { get; set; }

        /// <summary>
        /// The duration set for the validity of the upload URL. If the upload isn&apos;t completed within this timeframe, it&apos;s marked as timed out.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("timeout")]
        public double? Timeout { get; set; }

        /// <summary>
        /// Upload media directly from a device using the url name or enter &apos;*&apos; to allow all.
        /// </summary>
        [SerializeField]
        [JsonProperty("corsOrigin")]
        public string? CorsOrigin { get; set; }

        [SerializeField]
        [JsonProperty("pushMediaSettings")]
        public DirectUploadResponse? PushMediaSettings { get; set; }
    }
}