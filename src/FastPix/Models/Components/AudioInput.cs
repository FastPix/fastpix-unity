

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class AudioInput
    {

        /// <summary>
        /// Type of overlay (currently only supports &apos;audio&apos;).
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public AudioInputType? Type { get; set; }

        /// <summary>
        /// URL of the audio track to replace the existing audio in the video.
        /// </summary>
        [SerializeField]
        [JsonProperty("swapTrackUrl")]
        public string? SwapTrackUrl { get; set; }

        /// <summary>
        /// List of additional audio tracks to overlay on the video.
        /// </summary>
        [SerializeField]
        [JsonProperty("imposeTracks")]
        public List<ImposeTrack>? ImposeTracks { get; set; }
    }
}