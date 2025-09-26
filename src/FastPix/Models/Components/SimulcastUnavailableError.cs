

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Returns the problem that has occured.<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    [Serializable]
    public class SimulcastUnavailableError
    {

        /// <summary>
        /// An error code indicating the type of the error.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("code")]
        public long? Code { get; set; }

        /// <summary>
        /// A descriptive message providing more details for the error<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
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