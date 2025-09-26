

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    using fastpix.io.Models.Requests;
    
    /// <summary>
    /// Request body for creating playback id for an media
    /// </summary>
    [Serializable]
    public class CreateMediaPlaybackIdRequestBody
    {

        /// <summary>
        /// Access policy for media content
        /// </summary>
        [SerializeField]
        [JsonProperty("accessPolicy")]
        public AccessPolicy AccessPolicy { get; set; } = default!;

        [SerializeField]
        [JsonProperty("accessRestrictions")]
        public CreateMediaPlaybackIdAccessRestrictions? AccessRestrictions { get; set; }

        /// <summary>
        /// DRM configuration ID (required if accessPolicy is &apos;drm&apos;)
        /// </summary>
        [SerializeField]
        [JsonProperty("drmConfigurationId")]
        public string? DrmConfigurationId { get; set; }

        /// <summary>
        /// The maximum resolution for the playback ID.
        /// </summary>
        [SerializeField]
        [JsonProperty("resolution")]
        public Resolution? Resolution { get; set; }
    }
}