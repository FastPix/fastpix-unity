

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Displays the result of the request.
    /// </summary>
    [Serializable]
    public class SimulcastUpdateResponseData
    {

        /// <summary>
        /// When you create the new simulcast, FastPix assign a universal unique identifier which can contain a maximum of 255 characters.
        /// </summary>
        [SerializeField]
        [JsonProperty("simulcastId")]
        public string? SimulcastId { get; set; }

        /// <summary>
        /// The RTMP hostname, combined with the application name, is crucial for connecting to third-party live streaming services and transmitting the live stream.
        /// </summary>
        [SerializeField]
        [JsonProperty("url")]
        public string? Url { get; set; }

        /// <summary>
        /// A unique stream key is generated for streaming, allowing the user to start streaming on any third-party platform using this key.
        /// </summary>
        [SerializeField]
        [JsonProperty("streamKey")]
        public string? StreamKey { get; set; }

        /// <summary>
        /// When the value is set to false, the simulcast will be disabled for the given stream
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