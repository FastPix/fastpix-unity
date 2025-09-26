

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class VideoInput
    {

        /// <summary>
        /// Defines the type of input.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        /// <summary>
        /// The url hosts the media file for FastPix, which needs to be downloaded to use further. It supports formats like MP3, MP4, MOV, MKV, or TS, and includes text tracks for subtitles/CC (SRT file/VTT file). While FastPix can handle various audio and video formats and codecs, using standard inputs can help with optimal processing speed.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("url")]
        public string Url { get; set; } = default!;

        /// <summary>
        /// Start time indicates where encoding should begin within the video file. For example, if you want to encode a segment from 3 minutes (180 seconds) to 6 minutes (360 seconds) in a 10-minute (600 seconds) video, the start time is 3 minutes (180 seconds). Note: Start time is always mentioned in seconds.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("startTime")]
        public double? StartTime { get; set; }

        /// <summary>
        /// End time indicates where encoding should end within the video file. For example, if you want to encode a segment from 3 minutes (180 seconds) to 6 minutes (360 seconds) in a 10-minute (600 seconds) video, the end time is 6 minutes (360 seconds). Note: End time is always mentioned in seconds.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("endTime")]
        public double? EndTime { get; set; }

        /// <summary>
        /// The url of the intro video which is to be added at the start of the video.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("introUrl")]
        public string? IntroUrl { get; set; }

        /// <summary>
        /// The url of the outro video which is to be added at the end of the video.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("outroUrl")]
        public string? OutroUrl { get; set; }

        /// <summary>
        /// The list of the startTime-endTime of the segments to be removed from the actual video.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("expungeSegments")]
        public List<string>? ExpungeSegments { get; set; }

        /// <summary>
        /// A list of media segments to be added or processed. Each segment includes details such as the URL of the media file and instructions on where it should be inserted in the final media composition. A segment can either specify an exact timestamp  (`insertAt`) or indicate that it should be added at the end (`insertAtEnd`).
        /// </summary>
        [SerializeField]
        [JsonProperty("segments")]
        public List<SegmentUnion>? Segments { get; set; }
    }
}