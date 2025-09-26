

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class DrmIdResponse
    {

        /// <summary>
        /// The unique identifier of the DRM configuration.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}