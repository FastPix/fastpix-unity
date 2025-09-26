

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
    public class UpdateMediaTrackResponseBody
    {

        /// <summary>
        /// Demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Contains details about the track that was added or updated.
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public UpdateTrackResponse? Data { get; set; }
    }
}