

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class TopErrorDetails
    {

        /// <summary>
        /// views affected by the specific errors.
        /// </summary>
        [SerializeField]
        [JsonProperty("percentage")]
        public TopErrorDetailsPercentage? Percentage { get; set; }

        /// <summary>
        /// percentage of unique viewers affected by the specific error.
        /// </summary>
        [SerializeField]
        [JsonProperty("uniqueViewersEffectedPercentage")]
        public UniqueViewersEffectedPercentage? UniqueViewersEffectedPercentage { get; set; }

        /// <summary>
        /// Information about the specific error.
        /// </summary>
        [SerializeField]
        [JsonProperty("notes")]
        public string? Notes { get; set; }

        /// <summary>
        /// error message or description.
        /// </summary>
        [SerializeField]
        [JsonProperty("message")]
        public string? Message { get; set; }

        /// <summary>
        /// The timestamp of when the error was last observed.
        /// </summary>
        [SerializeField]
        [JsonProperty("lastSeen")]
        public string? LastSeen { get; set; }

        /// <summary>
        /// unique identifier for the specific error.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// description of the specific error.
        /// </summary>
        [SerializeField]
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Number of occurrences of the specific error.
        /// </summary>
        [SerializeField]
        [JsonProperty("count")]
        public long? Count { get; set; }

        /// <summary>
        /// Error code associated with the specific error.
        /// </summary>
        [SerializeField]
        [JsonProperty("code")]
        public string? Code { get; set; }
    }
}