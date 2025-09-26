

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class MediaClipResponseData
    {

        /// <summary>
        /// A video thumbnail that acts as a preview image for the video.
        /// </summary>
        [SerializeField]
        [JsonProperty("thumbnail")]
        public string? Thumbnail { get; set; }

        /// <summary>
        /// The unique identifier assigned to the media by FastPix.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The ID of the original source media.
        /// </summary>
        [SerializeField]
        [JsonProperty("sourceMediaId")]
        public string? SourceMediaId { get; set; }

        /// <summary>
        /// The unique identifier for the workspace associated with the media.
        /// </summary>
        [SerializeField]
        [JsonProperty("workspaceId")]
        public string? WorkspaceId { get; set; }

        /// <summary>
        /// Tag a video in &quot;key&quot; : &quot;value&quot; pairs for searchable metadata. Maximum 10 entries, 255 characters each.
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }

        /// <summary>
        /// The maximum resolution specified for the media.
        /// </summary>
        [SerializeField]
        [JsonProperty("maxResolution")]
        public MediaClipResponseMaxResolution? MaxResolution { get; set; }

        /// <summary>
        /// The actual resolution of the uploaded media.
        /// </summary>
        [SerializeField]
        [JsonProperty("sourceResolution")]
        public MediaClipResponseSourceResolution? SourceResolution { get; set; }

        /// <summary>
        /// The current processing status of the media.
        /// </summary>
        [SerializeField]
        [JsonProperty("status")]
        public Status? Status { get; set; }

        /// <summary>
        /// Indicates whether the original media file is accessible.
        /// </summary>
        [SerializeField]
        [JsonProperty("sourceAccess")]
        public bool? SourceAccess { get; set; }

        [SerializeField]
        [JsonProperty("playbackIds")]
        public List<MediaClipResponsePlaybackId>? PlaybackIds { get; set; }

        [SerializeField]
        [JsonProperty("tracks")]
        public List<MediaClipResponseTrack>? Tracks { get; set; }

        /// <summary>
        /// Generated subtitle tracks associated with the media.
        /// </summary>
        [SerializeField]
        [JsonProperty("generatedSubtitles")]
        public List<GeneratedSubtitle>? GeneratedSubtitles { get; set; }

        /// <summary>
        /// Indicates whether the media contains only audio.
        /// </summary>
        [SerializeField]
        [JsonProperty("isAudioOnly")]
        public bool? IsAudioOnly { get; set; }

        /// <summary>
        /// Indicates whether subtitles are available for the media.
        /// </summary>
        [SerializeField]
        [JsonProperty("subtitleAvailable")]
        public bool? SubtitleAvailable { get; set; }

        /// <summary>
        /// The total duration of the media.
        /// </summary>
        [SerializeField]
        [JsonProperty("duration")]
        public string? Duration { get; set; }

        /// <summary>
        /// The aspect ratio of the media.
        /// </summary>
        [SerializeField]
        [JsonProperty("aspectRatio")]
        public string? AspectRatio { get; set; }

        /// <summary>
        /// Timestamp of when the media was created.
        /// </summary>
        [SerializeField]
        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Timestamp of when the media was last updated.
        /// </summary>
        [SerializeField]
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}