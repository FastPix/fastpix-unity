

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Upload cancelled successfully
    /// </summary>
    [Serializable]
    public class CancelUploadResponseBody
    {

        /// <summary>
        /// Demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Response returned when an upload is cancelled.
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public MediaCancelResponse? Data { get; set; }
    }
}