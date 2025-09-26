

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Response returned when an upload is cancelled.
    /// </summary>
    [Serializable]
    public class MediaCancelResponse
    {

        /// <summary>
        /// The unique identifier of the cancelled upload.
        /// </summary>
        [SerializeField]
        [JsonProperty("uploadId")]
        public string? UploadId { get; set; }

        /// <summary>
        /// Indicates if the upload was a trial.
        /// </summary>
        [SerializeField]
        [JsonProperty("trial")]
        public bool? Trial { get; set; }

        /// <summary>
        /// The status of the upload after cancellation.
        /// </summary>
        [SerializeField]
        [JsonProperty("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The upload URL (if available) after cancellation.
        /// </summary>
        [SerializeField]
        [JsonProperty("url")]
        public string? Url { get; set; }

        /// <summary>
        /// The timeout value for the upload.
        /// </summary>
        [SerializeField]
        [JsonProperty("timeout")]
        public long? Timeout { get; set; }

        /// <summary>
        /// CORS origin allowed for the upload.
        /// </summary>
        [SerializeField]
        [JsonProperty("corsOrigin")]
        public string? CorsOrigin { get; set; }

        /// <summary>
        /// The maximum resolution allowed for the upload.
        /// </summary>
        [SerializeField]
        [JsonProperty("maxResolution")]
        public string? MaxResolution { get; set; }

        /// <summary>
        /// The access policy for the upload.
        /// </summary>
        [SerializeField]
        [JsonProperty("accessPolicy")]
        public string? AccessPolicy { get; set; }

        /// <summary>
        /// You can search for videos with specific key value pairs using metadata, when you tag a video in &quot;key&quot; : &quot;value&quot; pairs. Dynamic Metadata allows you to define a key that allows any value pair. You can have maximum of 255 characters and upto 10 entries are allowed.
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }
    }
}