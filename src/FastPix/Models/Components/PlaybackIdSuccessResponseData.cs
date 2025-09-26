

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class PlaybackIdSuccessResponseData
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