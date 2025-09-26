

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class Segment1
    {

        /// <summary>
        /// URL of the segment to be added.
        /// </summary>
        [SerializeField]
        [JsonProperty("url")]
        public string Url { get; set; } = default!;

        /// <summary>
        /// The timestamp at which the segment should be inserted.
        /// </summary>
        [SerializeField]
        [JsonProperty("insertAt")]
        public long InsertAt { get; set; } = default!;
    }
}