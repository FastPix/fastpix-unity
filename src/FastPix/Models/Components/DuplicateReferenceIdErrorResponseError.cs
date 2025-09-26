

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
    public class DuplicateReferenceIdErrorResponseError
    {

        /// <summary>
        /// Displays the error code indicating the type of the error.
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

        /// <summary>
        /// A detailed explanation of the possible causes for the error.<br/>
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