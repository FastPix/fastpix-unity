

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Controls access based on domains and user agents. Defines a default policy (either &quot;allow&quot; or &quot;deny&quot;) and provides lists for explicitly allowed or denied domains and user agents.
    /// </summary>
    [Serializable]
    public class PlaybackIdAccessRestrictions
    {

        /// <summary>
        /// Restrictions based on the originating domain of a request (e.g., whether requests from certain websites should be allowed or blocked).
        /// </summary>
        [SerializeField]
        [JsonProperty("domains")]
        public PlaybackIdDomains? Domains { get; set; }

        /// <summary>
        /// Restrictions based on the user agent (which is typically a string sent by browsers or bots identifying themselves).
        /// </summary>
        [SerializeField]
        [JsonProperty("userAgents")]
        public PlaybackIdUserAgents? UserAgents { get; set; }
    }
}