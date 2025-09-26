

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Direct upload created successfully
    /// </summary>
    [Serializable]
    public class DirectUploadVideoMediaResponseBody
    {

        /// <summary>
        /// Demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Displays the result of the request.
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public DirectUpload? Data { get; set; }
    }
}