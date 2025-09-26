

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Retrieves a list of the top video views
    /// </summary>
    [Serializable]
    public class ViewsByTopContentDetails
    {

        /// <summary>
        /// Title of the video
        /// </summary>
        [SerializeField]
        [JsonProperty("videoTitle")]
        public string? VideoTitle { get; set; }

        /// <summary>
        /// Total count of view sessions for a paricular video content.
        /// </summary>
        [SerializeField]
        [JsonProperty("views")]
        public long? Views { get; set; }

        /// <summary>
        /// Total count of unique video viewers for particular video content.
        /// </summary>
        [SerializeField]
        [JsonProperty("uniqueViews")]
        public long? UniqueViews { get; set; }
    }
}