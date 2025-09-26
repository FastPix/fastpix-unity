

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Displays the result of the request.
    /// </summary>
    [Serializable]
    public class PatchResponseData
    {

        /// <summary>
        /// Upon creating a new live stream, FastPix assigns a unique identifier to the stream.
        /// </summary>
        [SerializeField]
        [JsonProperty("streamId")]
        public string? StreamId { get; set; }

        /// <summary>
        /// A unique stream key is generated for streaming, allowing the user to start streaming on any third-party platform using this key.
        /// </summary>
        [SerializeField]
        [JsonProperty("streamKey")]
        public string? StreamKey { get; set; }

        /// <summary>
        /// A secret used for securing the SRT stream. This ensures that only authorized users can access the stream.
        /// </summary>
        [SerializeField]
        [JsonProperty("srtSecret")]
        public string? SrtSecret { get; set; }

        /// <summary>
        /// FastPix allows for a to trial the live stream for free. The duration of trial streams is five minutes. After five minutes of activity, the trial stream is turned off, and the recorded asset is removed after a day.
        /// </summary>
        [SerializeField]
        [JsonProperty("trial")]
        public bool? Trial { get; set; }

        /// <summary>
        /// The current live stream status can be one of four values:Idle, Preparing, Active or Disabled.The Idle status signifies that there isn&apos;t a broadcast in progress.The preparing status indicates that the stream is getting prepared. while, the Active status indicates that a broadcast is currently in progress. The Disabled status means that no more RTMPS streams can be published.
        /// </summary>
        [SerializeField]
        [JsonProperty("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Max resolution can be used to control the maximum resolution your media is encoded, stored, and streamed at.
        /// </summary>
        [SerializeField]
        [JsonProperty("maxResolution")]
        public string? MaxResolution { get; set; }

        /// <summary>
        /// The maximum duration in seconds that a live stream can have before it ends the stream.
        /// </summary>
        [SerializeField]
        [JsonProperty("maxDuration")]
        public long? MaxDuration { get; set; }

        /// <summary>
        /// It is the moment when the stream was created Time the media was generated, defined as a localDateTime (UTC Time).
        /// </summary>
        [SerializeField]
        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// In case the software streaming the live, gets disrupted for any reason and gets disconnected from FastPix, the reconnect window specifies the time span FastPix will wait before ending the stream. Before starting the stream, you can set the reconnect window time which is up to 1800 seconds.
        /// </summary>
        [SerializeField]
        [JsonProperty("reconnectWindow")]
        public long? ReconnectWindow { get; set; }

        /// <summary>
        /// When set to true, the livestream will be recorded and stored for later viewing purposes. If set to false, the livestream will not be recorded.
        /// </summary>
        [SerializeField]
        [JsonProperty("enableRecording")]
        public bool? EnableRecording { get; set; }

        /// <summary>
        /// Determines whether the recorded stream should be publicly accessible or private in Live to VOD (Video on Demand).
        /// </summary>
        [SerializeField]
        [JsonProperty("mediaPolicy")]
        public string? MediaPolicy { get; set; }

        /// <summary>
        /// You can search for videos with specific key value pairs using metadata, when you tag a video in &quot;key&quot;:&quot;value&quot;s pairs. Dynamic Metadata allows you to define a key that allows any value pair. You can have maximum of 255 characters and upto 10 entries are allowed.
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }

        [SerializeField]
        [JsonProperty("playbackIds")]
        public List<PlaybackIdResponse>? PlaybackIds { get; set; }

        /// <summary>
        /// This object contains the livestream playback response details for SRT Protocol
        /// </summary>
        [SerializeField]
        [JsonProperty("srtPlaybackResponse")]
        public SrtPlaybackResponse? SrtPlaybackResponse { get; set; }
    }
}