

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// This object contains the livestream playback response details for SRT Protocol
    /// </summary>
    [Serializable]
    public class SrtPlaybackResponse
    {

        /// <summary>
        /// A unique identifier for the SRT playback stream. This ID is used to distinguish between different playback streams
        /// </summary>
        [SerializeField]
        [JsonProperty("srtPlaybackStreamId")]
        public string? SrtPlaybackStreamId { get; set; }

        /// <summary>
        /// A playback secret used for securing the SRT playback stream. This ensures that only authorized users can access the playback
        /// </summary>
        [SerializeField]
        [JsonProperty("srtPlaybackSecret")]
        public string? SrtPlaybackSecret { get; set; }
    }
}