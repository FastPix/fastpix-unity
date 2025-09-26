

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// A media consists of different media tracks, like video, audio, and subtitle, all combined.
    /// </summary>
    [Serializable]
    public class Track
    {

        /// <summary>
        /// FastPix generates a unique identifier for each track.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Defines the type of input. This option is mandatory.
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        /// <summary>
        /// Track width denotes the range of widths applicable to a specific track. Currently, this setting can be modified only for video tracks
        /// </summary>
        [SerializeField]
        [JsonProperty("width")]
        public double? Width { get; set; }

        /// <summary>
        /// Track height denotes the range of height applicable to a specific track. Currently, this setting can be modified only for video tracks.
        /// </summary>
        [SerializeField]
        [JsonProperty("height")]
        public double? Height { get; set; }

        /// <summary>
        /// Frame rate quantifies the speed at which frames are displayed per second. It represents the range of frames available for a specific track. If the frame rate of the input file is indeterminable, it will be indicated by a value of -1.
        /// </summary>
        [SerializeField]
        [JsonProperty("frameRate")]
        public string? FrameRate { get; set; }

        /// <summary>
        /// Indicates if the track contains closed captions.
        /// </summary>
        [SerializeField]
        [JsonProperty("closedCaptions")]
        public bool? ClosedCaptions { get; set; }
    }
}