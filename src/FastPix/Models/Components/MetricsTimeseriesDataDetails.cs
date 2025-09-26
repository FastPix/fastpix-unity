

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// The metric&apos;s value at specific time intervals.
    /// </summary>
    [Serializable]
    public class MetricsTimeseriesDataDetails
    {

        /// <summary>
        /// The timestamp for the data point indicating when the metric value was recorded.
        /// </summary>
        [SerializeField]
        [JsonProperty("intervalTime")]
        public DateTime? IntervalTime { get; set; }

        /// <summary>
        /// The value of the specified metric at the given interval.
        /// </summary>
        [SerializeField]
        [JsonProperty("metricValue")]
        public MetricValue? MetricValue { get; set; }

        /// <summary>
        /// The total number of views recorded during that interval.
        /// </summary>
        [SerializeField]
        [JsonProperty("numberOfViews")]
        public long? NumberOfViews { get; set; }
    }
}