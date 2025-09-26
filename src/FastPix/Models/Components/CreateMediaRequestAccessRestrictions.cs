

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class CreateMediaRequestAccessRestrictions
    {

        [SerializeField]
        [JsonProperty("domains")]
        public CreateMediaRequestDomains? Domains { get; set; }

        [SerializeField]
        [JsonProperty("userAgents")]
        public CreateMediaRequestUserAgents? UserAgents { get; set; }
    }
}