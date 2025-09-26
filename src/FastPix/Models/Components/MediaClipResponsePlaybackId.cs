

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class MediaClipResponsePlaybackId
    {

        /// <summary>
        /// The unique identifier for playback.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The access policy of the playback.
        /// </summary>
        [SerializeField]
        [JsonProperty("accessPolicy")]
        public string? AccessPolicy { get; set; }

        [SerializeField]
        [JsonProperty("accessRestrictions")]
        public MediaClipResponseAccessRestrictions? AccessRestrictions { get; set; }
    }
}