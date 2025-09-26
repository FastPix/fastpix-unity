

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class BrowserNameDimensiondetails
    {

        /// <summary>
        /// The specific metric value calculated based on the applied filters.
        /// </summary>
        [SerializeField]
        [JsonProperty("value")]
        public string Value { get; set; } = default!;

        /// <summary>
        /// The count of unique viewers who interacted with the content.
        /// </summary>
        [SerializeField]
        [JsonProperty("uniqueCount")]
        public long? UniqueCount { get; set; }

        /// <summary>
        /// The count of viewers.
        /// </summary>
        [SerializeField]
        [JsonProperty("count")]
        public long Count { get; set; } = default!;
    }
}