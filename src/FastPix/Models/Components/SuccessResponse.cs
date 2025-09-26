

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class SuccessResponse
    {

        /// <summary>
        /// Demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool Success { get; set; } = default!;

        /// <summary>
        /// Array of response data
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public List<SuccessResponseData> Data { get; set; } = default!;
    }
}