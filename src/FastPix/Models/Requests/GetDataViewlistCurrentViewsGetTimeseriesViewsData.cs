

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class GetDataViewlistCurrentViewsGetTimeseriesViewsData
    {

        /// <summary>
        /// The timestamp for the interval (ISO 8601 format).
        /// </summary>
        [SerializeField]
        [JsonProperty("intervalTime")]
        public DateTime? IntervalTime { get; set; }

        /// <summary>
        /// Reserved for future metric values (currently null).
        /// </summary>
        [SerializeField]
        [JsonProperty("metricValue")]
        public long? MetricValue { get; set; }

        /// <summary>
        /// Number of concurrent viewers at the given interval.
        /// </summary>
        [SerializeField]
        [JsonProperty("numberOfViews")]
        public long? NumberOfViews { get; set; }
    }
}