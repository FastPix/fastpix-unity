

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class ImposeTrack
    {

        /// <summary>
        /// URL of the audio track to impose on the video.
        /// </summary>
        [SerializeField]
        [JsonProperty("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Start time (in seconds) of the imposed audio in the video.
        /// </summary>
        [SerializeField]
        [JsonProperty("startTime")]
        public long? StartTime { get; set; }

        /// <summary>
        /// End time (in seconds) of the imposed audio in the video.
        /// </summary>
        [SerializeField]
        [JsonProperty("endTime")]
        public long? EndTime { get; set; }

        /// <summary>
        /// Level of fade-in effect (in seconds) at the start of the imposed audio.
        /// </summary>
        [SerializeField]
        [JsonProperty("fadeInLevel")]
        public long? FadeInLevel { get; set; }

        /// <summary>
        /// Level of fade-out effect (in seconds) at the end of the imposed audio.
        /// </summary>
        [SerializeField]
        [JsonProperty("fadeOutLevel")]
        public long? FadeOutLevel { get; set; }
    }
}