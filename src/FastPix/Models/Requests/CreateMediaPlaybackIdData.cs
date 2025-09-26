

#nullable enable
namespace fastpix.io.Models.Requests
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
    public class CreateMediaPlaybackIdData
    {

        /// <summary>
        /// A collection of Playback ID objects utilized for crafting HLS playback URLs.
        /// </summary>
        [SerializeField]
        [JsonProperty("playbackIds")]
        public List<PlaybackId>? PlaybackIds { get; set; }
    }
}