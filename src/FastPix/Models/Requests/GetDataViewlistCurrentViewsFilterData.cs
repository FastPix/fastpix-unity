

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class GetDataViewlistCurrentViewsFilterData
    {

        /// <summary>
        /// Number of concurrent viewers for this dimension value.
        /// </summary>
        [SerializeField]
        [JsonProperty("concurrent_viewers")]
        public long? ConcurrentViewers { get; set; }

        /// <summary>
        /// Name of the dimension (e.g., country, device type, etc.).
        /// </summary>
        [SerializeField]
        [JsonProperty("dimension_name")]
        public string? DimensionName { get; set; }

        /// <summary>
        /// Additional metric value for this dimension (if applicable).
        /// </summary>
        [SerializeField]
        [JsonProperty("metricValue")]
        public long? MetricValue { get; set; }
    }
}