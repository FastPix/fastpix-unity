

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    
    /// <summary>
    /// Request body for direct upload
    /// </summary>
    [Serializable]
    public class DirectUploadVideoMediaRequest
    {

        /// <summary>
        /// Upload media directly from a device using the URL name or enter &apos;*&apos; to allow all.
        /// </summary>
        [SerializeField]
        [JsonProperty("corsOrigin")]
        public string CorsOrigin { get; set; } = default!;

        /// <summary>
        /// Configuration settings for media upload.
        /// </summary>
        [SerializeField]
        [JsonProperty("pushMediaSettings")]
        public PushMediaSettings? PushMediaSettings { get; set; }
    }
}