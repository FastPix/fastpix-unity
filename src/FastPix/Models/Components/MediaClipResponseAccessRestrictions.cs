

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class MediaClipResponseAccessRestrictions
    {

        [SerializeField]
        [JsonProperty("domains")]
        public MediaClipResponseDomains? Domains { get; set; }

        [SerializeField]
        [JsonProperty("userAgents")]
        public MediaClipResponseUserAgents? UserAgents { get; set; }
    }
}