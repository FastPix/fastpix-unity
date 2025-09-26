

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Displays the result of the request.
    /// </summary>
    [Serializable]
    public class ListErrorsData
    {

        /// <summary>
        /// Retrieves a list of errors that have occurred in the system.
        /// </summary>
        [SerializeField]
        [JsonProperty("errors")]
        public List<ErrorDetails>? Errors { get; set; }

        /// <summary>
        /// Retrieves a list of errors that have occurred most frequently in the system, ranked by their count of occurrences.
        /// </summary>
        [SerializeField]
        [JsonProperty("topErrors")]
        public List<TopErrorDetails>? TopErrors { get; set; }
    }
}