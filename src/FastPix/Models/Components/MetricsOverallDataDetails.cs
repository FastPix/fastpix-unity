

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Retrieves overall values for a specified metric
    /// </summary>
    [Serializable]
    public class MetricsOverallDataDetails
    {

        /// <summary>
        /// metric value calculated based on the applied filters.
        /// </summary>
        [SerializeField]
        [JsonProperty("value")]
        public MetricsOverallDataDetailsValue? Value { get; set; }

        /// <summary>
        /// Total time watched across all views, represented in milliseconds.
        /// </summary>
        [SerializeField]
        [JsonProperty("totalWatchTime")]
        public long? TotalWatchTime { get; set; }

        /// <summary>
        /// The count of unique viewers who interacted with the content.
        /// </summary>
        [SerializeField]
        [JsonProperty("uniqueViews")]
        public long? UniqueViews { get; set; }

        /// <summary>
        /// The total number of views recorded.
        /// </summary>
        [SerializeField]
        [JsonProperty("totalViews")]
        public long? TotalViews { get; set; }

        /// <summary>
        /// Total time spent playing the video, represented in milliseconds.
        /// </summary>
        [SerializeField]
        [JsonProperty("totalPlayTime")]
        public long? TotalPlayTime { get; set; }

        /// <summary>
        /// A global metric value that reflects the overall performance of the specified metric across the entire dataset for the given timespan.
        /// </summary>
        [SerializeField]
        [JsonProperty("globalValue")]
        public GlobalValue? GlobalValue { get; set; }
    }
}