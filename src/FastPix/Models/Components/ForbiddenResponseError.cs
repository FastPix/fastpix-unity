

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Displays details about the reasons behind the request&apos;s failure.
    /// </summary>
    [Serializable]
    public class ForbiddenResponseError
    {

        /// <summary>
        /// Forbidden response
        /// </summary>
        [SerializeField]
        [JsonProperty("code")]
        public long? Code { get; set; }

        /// <summary>
        /// A descriptive message providing more details for the error.
        /// </summary>
        [SerializeField]
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}