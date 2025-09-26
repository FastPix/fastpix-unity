

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class CreateMediaRequestDomains
    {

        /// <summary>
        /// Policy action type
        /// </summary>
        [SerializeField]
        [JsonProperty("defaultPolicy")]
        public PolicyAction? DefaultPolicy { get; set; }

        /// <summary>
        /// A list of domain names or patterns that are explicitly allowed access. <br/>
        /// 
        /// <remarks>
        /// This list is only effective when the `defaultPolicy` is set to `deny`.<br/>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("allow")]
        public List<string>? Allow { get; set; }

        /// <summary>
        /// A list of domain names or patterns that are explicitly denied access. <br/>
        /// 
        /// <remarks>
        /// This list is only effective when the `defaultPolicy` is set to `allow`.<br/>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("deny")]
        public List<string>? Deny { get; set; }
    }
}