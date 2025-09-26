

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Pagination organizes content into pages for better readability and navigation.
    /// </summary>
    [Serializable]
    public class Pagination
    {

        /// <summary>
        /// It gives the total number of media assets that are accessible overall.
        /// </summary>
        [SerializeField]
        [JsonProperty("totalRecords")]
        public long? TotalRecords { get; set; }

        /// <summary>
        /// Offset determines the current point for data retrieval within a paginated list. 
        /// </summary>
        [SerializeField]
        [JsonProperty("currentOffset")]
        public long? CurrentOffset { get; set; }

        /// <summary>
        /// The offset count is expressed as total records by limit
        /// </summary>
        [SerializeField]
        [JsonProperty("offsetCount")]
        public long? OffsetCount { get; set; }
    }
}