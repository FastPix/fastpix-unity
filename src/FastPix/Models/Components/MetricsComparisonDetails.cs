

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class MetricsComparisonDetails
    {

        /// <summary>
        /// The specific metric value calculated based on the applied filters.
        /// </summary>
        [SerializeField]
        [JsonProperty("value")]
        public long? Value { get; set; }

        /// <summary>
        /// value can be score that ranges from 0 to 100
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public string? Type { get; set; }

        /// <summary>
        /// value can be score that ranges from 0 to 100
        /// </summary>
        [SerializeField]
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The metric field represents the name of the Key Performance Indicator (KPI) being tracked or analyzed. It identifies a specific measurable aspect of the video playback experience, such as buffering time, video start failure rate, or playback quality.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("metric")]
        public string? Metric { get; set; }

        [SerializeField]
        [JsonProperty("items")]
        public List<Item>? Items { get; set; }
    }
}