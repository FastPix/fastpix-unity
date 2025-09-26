

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    using fastpix.io.Models.Requests;
    
    /// <summary>
    /// Configuration settings for media upload.
    /// </summary>
    [Serializable]
    public class PushMediaSettings
    {

        /// <summary>
        /// Basic access policy for media content
        /// </summary>
        [SerializeField]
        [JsonProperty("accessPolicy")]
        public BasicAccessPolicy AccessPolicy { get; set; } = default!;

        /// <summary>
        /// Start time indicates where encoding should begin within the video file, in seconds.
        /// </summary>
        [SerializeField]
        [JsonProperty("startTime")]
        public double? StartTime { get; set; }

        /// <summary>
        /// End time indicates where encoding should end within the video file, in seconds.
        /// </summary>
        [SerializeField]
        [JsonProperty("endTime")]
        public double? EndTime { get; set; }

        [SerializeField]
        [JsonProperty("inputs")]
        public List<fastpix.io.Models.Requests.Input>? Inputs { get; set; }

        /// <summary>
        /// Tag a video in &quot;key&quot; : &quot;value&quot; pairs for searchable metadata. Maximum 10 entries, 255 characters each.
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }

        /// <summary>
        /// Generates subtitle files for audio/video files.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("subtitles")]
        public fastpix.io.Models.Requests.Subtitles? Subtitles { get; set; }

        /// <summary>
        /// Enhance the quality and volume of the audio track. This is available for pre-recorded content only.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("optimizeAudio")]
        public bool? OptimizeAudio { get; set; }

        /// <summary>
        /// Determines the highest quality resolution available.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("maxResolution")]
        public MaxResolution? MaxResolution { get; set; }

        /// <summary>
        /// The sourceAccess parameter determines whether the original media file is accessible. Set to true to enable access or false to restrict it
        /// </summary>
        [SerializeField]
        [JsonProperty("sourceAccess")]
        public bool? SourceAccess { get; set; }

        /// <summary>
        /// Generates MP4 video up to 4K (&quot;capped_4k&quot;), m4a audio only (&quot;audioOnly&quot;), or both for offline viewing.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("mp4Support")]
        public DirectUploadVideoMediaMp4Support? Mp4Support { get; set; }

        [SerializeField]
        [JsonProperty("summary")]
        public fastpix.io.Models.Requests.Summary? Summary { get; set; }

        /// <summary>
        /// Enable or disable the chapters feature for the media. Set to `true` to enable chapters or `false` to disable.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("chapters")]
        public bool? Chapters { get; set; }

        /// <summary>
        /// Enable or disable named entity extraction. Set to `true` to enable or `false` to disable.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("namedEntities")]
        public bool? NamedEntities { get; set; }

        [SerializeField]
        [JsonProperty("moderation")]
        public DirectUploadVideoMediaModeration? Moderation { get; set; }

        [SerializeField]
        [JsonProperty("accessRestrictions")]
        public DirectUploadVideoMediaAccessRestrictions? AccessRestrictions { get; set; }
    }
}