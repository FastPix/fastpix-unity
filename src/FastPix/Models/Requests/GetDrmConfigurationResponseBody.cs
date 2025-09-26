

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// DRM configuration(s) retrieved successfully
    /// </summary>
    [Serializable]
    public class GetDrmConfigurationResponseBody
    {

        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [SerializeField]
        [JsonProperty("data")]
        public List<DrmIdResponse>? Data { get; set; }

        /// <summary>
        /// Pagination organizes content into pages for better readability and navigation.
        /// </summary>
        [SerializeField]
        [JsonProperty("pagination")]
        public Pagination? Pagination { get; set; }
    }
}