

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class PatchLiveStreamRequest
    {

        /// <summary>
        /// You can search for videos with specific key value pairs using metadata, when you tag a video in &quot;key&quot;:&quot;value&quot;s pairs. Dynamic Metadata allows you to define a key that allows any value pair. You can have maximum of 255 characters and upto 10 entries are allowed.
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }

        /// <summary>
        /// In case the software streaming the live, gets disrupted for any reason and gets disconnected from FastPix, the reconnect window specifies the time span FastPix will wait before ending the stream. Before starting the stream, you can set the reconnect window time which is up to 1800 seconds.
        /// </summary>
        [SerializeField]
        [JsonProperty("reconnectWindow")]
        public long? ReconnectWindow { get; set; }
    }
}