

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Required when playlist type is smart - media created between startDate and endDate of createdDate will be add, similarily updatedDate (Optional)
    /// </summary>
    [Serializable]
    public class CreatePlaylistRequestMetadata
    {

        /// <summary>
        /// Date range with start and end dates.
        /// </summary>
        [SerializeField]
        [JsonProperty("createdDate")]
        public DateRange? CreatedDate { get; set; }

        /// <summary>
        /// Date range with start and end dates.
        /// </summary>
        [SerializeField]
        [JsonProperty("updatedDate")]
        public DateRange? UpdatedDate { get; set; }
    }
}