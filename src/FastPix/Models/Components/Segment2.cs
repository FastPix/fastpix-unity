

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class Segment2
    {

        /// <summary>
        /// URL of the segment to be added.
        /// </summary>
        [SerializeField]
        [JsonProperty("url")]
        public string Url { get; set; } = default!;

        /// <summary>
        /// Flag indicating the segment should be inserted at the end.
        /// </summary>
        [SerializeField]
        [JsonProperty("insertAtEnd")]
        public bool InsertAtEnd { get; set; } = default!;
    }
}