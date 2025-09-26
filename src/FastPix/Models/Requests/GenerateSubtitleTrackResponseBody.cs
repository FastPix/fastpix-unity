

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Media details updated successfully
    /// </summary>
    [Serializable]
    public class GenerateSubtitleTrackResponseBody
    {

        /// <summary>
        /// Demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Represents the response for a successfully generated subtitle track.
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public GenerateTrackResponse? Data { get; set; }
    }
}