

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Restrictions based on the user agent (which is typically a string sent by browsers or bots identifying themselves).
    /// </summary>
    [Serializable]
    public class PlaybackIdUserAgents
    {

        /// <summary>
        /// Policy action type
        /// </summary>
        [SerializeField]
        [JsonProperty("defaultPolicy")]
        public PolicyAction? DefaultPolicy { get; set; }

        /// <summary>
        /// A list of specific user agents that are allowed to access the resource.
        /// </summary>
        [SerializeField]
        [JsonProperty("allow")]
        public List<string>? Allow { get; set; }

        /// <summary>
        /// A list of specific user agents that are blocked.
        /// </summary>
        [SerializeField]
        [JsonProperty("deny")]
        public List<string>? Deny { get; set; }
    }
}