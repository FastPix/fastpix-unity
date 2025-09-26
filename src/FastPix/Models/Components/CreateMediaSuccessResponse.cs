

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class CreateMediaSuccessResponse
    {

        /// <summary>
        /// Demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool Success { get; set; } = default!;

        [SerializeField]
        [JsonProperty("data")]
        public fastpix.io.Models.Components.CreateMediaResponse Data { get; set; } = default!;
    }
}