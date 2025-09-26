

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Retrieves breakdown values for a specified metric and timespan
    /// </summary>
    [Serializable]
    public class MetricsTimeseriesMetaDataDetails
    {

        /// <summary>
        /// the unit for aggregating the timeseries data.
        /// </summary>
        [SerializeField]
        [JsonProperty("granularity")]
        public string? Granularity { get; set; }

        /// <summary>
        /// defines the field or dimension on which the aggregation is to be   applied.
        /// </summary>
        [SerializeField]
        [JsonProperty("aggregation")]
        public string? Aggregation { get; set; }
    }
}