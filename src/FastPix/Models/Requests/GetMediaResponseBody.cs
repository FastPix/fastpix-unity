

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Get a video media by id
    /// </summary>
    [Serializable]
    public class GetMediaResponseBody
    {

        /// <summary>
        /// Demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [SerializeField]
        [JsonProperty("data")]
        public Media? Data { get; set; }
    }
}