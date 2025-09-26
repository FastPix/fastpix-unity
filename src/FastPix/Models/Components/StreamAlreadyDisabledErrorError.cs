

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Contains details explaining why the request failed.
    /// </summary>
    [Serializable]
    public class StreamAlreadyDisabledErrorError
    {

        /// <summary>
        /// HTTP status code indicating the nature of the error.
        /// </summary>
        [SerializeField]
        [JsonProperty("code")]
        public double? Code { get; set; }

        /// <summary>
        /// A short message summarizing the error.
        /// </summary>
        [SerializeField]
        [JsonProperty("message")]
        public string? Message { get; set; }

        /// <summary>
        /// A detailed explanation indicating that the stream is already in a disabled state and cannot be disabled again.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}