

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class CreateMediaPlaybackIdAccessRestrictions
    {

        /// <summary>
        /// Restrictions based on the originating domain of a request
        /// </summary>
        [SerializeField]
        [JsonProperty("domains")]
        public DomainRestrictions? Domains { get; set; }

        /// <summary>
        /// Restrictions based on the user agent
        /// </summary>
        [SerializeField]
        [JsonProperty("userAgents")]
        public UserAgentRestrictions? UserAgents { get; set; }
    }
}