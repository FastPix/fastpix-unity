

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class MediaClipResponsePagination
    {

        /// <summary>
        /// Total number of records available.
        /// </summary>
        [SerializeField]
        [JsonProperty("totalRecords")]
        public long? TotalRecords { get; set; }

        /// <summary>
        /// The starting offset of the current result set.
        /// </summary>
        [SerializeField]
        [JsonProperty("currentOffset")]
        public long? CurrentOffset { get; set; }

        /// <summary>
        /// The number of items returned in the current response.
        /// </summary>
        [SerializeField]
        [JsonProperty("offsetCount")]
        public long? OffsetCount { get; set; }
    }
}