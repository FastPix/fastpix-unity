

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// date range filter used when creating the smart playlist
    /// </summary>
    [Serializable]
    public class PlaylistCreatedSchemaMetadata
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