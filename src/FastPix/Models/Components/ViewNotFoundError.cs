

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Returns the problem that has occured
    /// </summary>
    [Serializable]
    public class ViewNotFoundError
    {

        /// <summary>
        /// An error code indicating the type of the error.
        /// </summary>
        [SerializeField]
        [JsonProperty("code")]
        public double? Code { get; set; }

        /// <summary>
        /// A descriptive message providing more details for the error.
        /// </summary>
        [SerializeField]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}