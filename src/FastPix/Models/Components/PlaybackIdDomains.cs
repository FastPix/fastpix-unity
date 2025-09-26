

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Restrictions based on the originating domain of a request (e.g., whether requests from certain websites should be allowed or blocked).
    /// </summary>
    [Serializable]
    public class PlaybackIdDomains
    {

        /// <summary>
        /// Policy action type
        /// </summary>
        [SerializeField]
        [JsonProperty("defaultPolicy")]
        public PolicyAction? DefaultPolicy { get; set; }

        /// <summary>
        /// A list of domains that are explicitly allowed access.
        /// </summary>
        [SerializeField]
        [JsonProperty("allow")]
        public List<string>? Allow { get; set; }

        /// <summary>
        /// A list of domains that are explicitly blocked from accessing the resource.
        /// </summary>
        [SerializeField]
        [JsonProperty("deny")]
        public List<string>? Deny { get; set; }
    }
}