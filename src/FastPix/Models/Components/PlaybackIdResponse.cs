

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// A collection of Playback ID objects utilized for crafting HLS playback urls.
    /// </summary>
    [Serializable]
    public class PlaybackIdResponse
    {

        /// <summary>
        /// Unique identifier for the playbackId
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Determines if access to the streamed content is kept private or available to all.
        /// </summary>
        [SerializeField]
        [JsonProperty("accessPolicy")]
        public string? AccessPolicy { get; set; }
    }
}