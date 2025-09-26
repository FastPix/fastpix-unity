

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class SimulcastUpdateRequest
    {

        /// <summary>
        /// When the value is set to false, the simulcast will be disabled for the given stream.
        /// </summary>
        [SerializeField]
        [JsonProperty("isEnabled")]
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// You can search for videos with specific key value pairs using metadata, when you tag a video in &quot;key&quot;:&quot;value&quot;s pairs. Dynamic Metadata allows you to define a key that allows any value pair. You can have maximum of 255 characters and upto 10 entries are allowed.
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }
    }
}