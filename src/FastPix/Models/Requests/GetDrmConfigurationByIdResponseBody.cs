

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// DRM configuration retrieved successfully
    /// </summary>
    [Serializable]
    public class GetDrmConfigurationByIdResponseBody
    {

        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [SerializeField]
        [JsonProperty("data")]
        public DrmIdResponse? Data { get; set; }
    }
}