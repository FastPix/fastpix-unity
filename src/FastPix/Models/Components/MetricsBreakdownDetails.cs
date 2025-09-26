

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class MetricsBreakdownDetails
    {

        /// <summary>
        /// Total count of view sessions for a paricular video content.
        /// </summary>
        [SerializeField]
        [JsonProperty("views")]
        public long? Views { get; set; }

        /// <summary>
        /// The specific metric value calculated based on the applied filters.
        /// </summary>
        [SerializeField]
        [JsonProperty("value", NullValueHandling = NullValueHandling.Include)]
        public MetricsBreakdownDetailsValue? Value { get; set; } = default!;

        /// <summary>
        /// Total time watched across all views, represented in milliseconds.
        /// </summary>
        [SerializeField]
        [JsonProperty("totalWatchTime")]
        public long? TotalWatchTime { get; set; }

        /// <summary>
        /// Total time spent playing the video, represented in milliseconds.
        /// </summary>
        [SerializeField]
        [JsonProperty("totalPlayingTime")]
        public long? TotalPlayingTime { get; set; }

        /// <summary>
        /// the value of dimension or filter value on which the aggregation is to be applied.
        /// </summary>
        [SerializeField]
        [JsonProperty("field")]
        public string? Field { get; set; }
    }
}