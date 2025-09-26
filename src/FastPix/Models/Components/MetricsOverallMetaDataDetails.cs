

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Metadata that has to be paased for metric calculations.
    /// </summary>
    [Serializable]
    public class MetricsOverallMetaDataDetails
    {

        /// <summary>
        /// defines the field or dimension on which the aggregation is to be   applied.
        /// </summary>
        [SerializeField]
        [JsonProperty("aggregation")]
        public string? Aggregation { get; set; }
    }
}