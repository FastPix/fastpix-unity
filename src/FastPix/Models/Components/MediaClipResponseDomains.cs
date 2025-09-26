

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class MediaClipResponseDomains
    {

        [SerializeField]
        [JsonProperty("defaultPolicy")]
        public string? DefaultPolicy { get; set; }

        [SerializeField]
        [JsonProperty("allow")]
        public List<string>? Allow { get; set; }

        [SerializeField]
        [JsonProperty("deny")]
        public List<string>? Deny { get; set; }
    }
}