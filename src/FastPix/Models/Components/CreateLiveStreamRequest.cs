

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class CreateLiveStreamRequest
    {

        /// <summary>
        /// Displays the result of the playback settings.
        /// </summary>
        [SerializeField]
        [JsonProperty("playbackSettings")]
        public PlaybackSettings PlaybackSettings { get; set; } = default!;

        /// <summary>
        /// Displays the result of the input Media settings.
        /// </summary>
        [SerializeField]
        [JsonProperty("inputMediaSettings")]
        public InputMediaSettings InputMediaSettings { get; set; } = default!;
    }
}