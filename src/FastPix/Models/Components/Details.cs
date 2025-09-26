

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class Details
    {

        /// <summary>
        /// The player_source_bitrate represents the bitrate of the video stream that is being played, measured in bits per second (bps). This value indicates the quality of the video being streamed, with higher bitrates typically corresponding to better video quality but requiring more bandwidth.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("player_source_bitrate")]
        public long? PlayerSourceBitrate { get; set; }

        /// <summary>
        /// The player_source_codec represents the video or audio codec being used to decode and play the media. A codec is a technology used to compress and decompress digital media files, enabling efficient transmission and storage while maintaining quality.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("player_source_codec")]
        public string? PlayerSourceCodec { get; set; }

        /// <summary>
        /// The player_source_height refers to the vertical resolution of the video being played, measured in pixels. This value represents the height dimension of the video frame and is part of the overall resolution of the video (e.g., 1920x1080, where the height is 1080 pixels).<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerSourceHeight")]
        public long? PlayerSourceHeight { get; set; }

        /// <summary>
        /// The player_source_width refers to the horizontal resolution of the video being played, measured in pixels. This value represents the width dimension of the video frame and is part of the overall video resolution (e.g., 1920x1080, where the width is 1920 pixels).<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("playerSourceWidth")]
        public long? PlayerSourceWidth { get; set; }
    }
}