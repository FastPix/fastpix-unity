

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Restrictions based on the originating domain of a request
    /// </summary>
    [Serializable]
    public class DomainRestrictions
    {

        /// <summary>
        /// Policy action type
        /// </summary>
        [SerializeField]
        [JsonProperty("defaultPolicy")]
        public PolicyAction? DefaultPolicy { get; set; }

        /// <summary>
        /// A list of domain names or patterns that are explicitly allowed access
        /// </summary>
        [SerializeField]
        [JsonProperty("allow")]
        public List<string>? Allow { get; set; }

        /// <summary>
        /// A list of domain names or patterns that are explicitly denied access
        /// </summary>
        [SerializeField]
        [JsonProperty("deny")]
        public List<string>? Deny { get; set; }
    }
}