

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class Item
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

        /// <summary>
        /// value can be avg, sum, count or 95th
        /// </summary>
        [SerializeField]
        [JsonProperty("measurement")]
        public string? Measurement { get; set; }
    }
}