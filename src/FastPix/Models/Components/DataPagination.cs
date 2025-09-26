

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
    public class DataPagination
    {

        /// <summary>
        /// The total number of records retrieved within the timeframe.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("totalRecords")]
        public long? TotalRecords { get; set; }

        /// <summary>
        /// The current offset value. <br/>
        /// 
        /// <remarks>
        /// <br/>
        /// Default: 1<br/>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("currentOffset")]
        public long? CurrentOffset { get; set; }

        /// <summary>
        /// The total number of offsets based on limit.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("offsetCount")]
        public long? OffsetCount { get; set; }
    }
}