

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Displays details about the reasons behind the request&apos;s failure.
    /// </summary>
    [Serializable]
    public class InvalidPlaylistIdResponseError
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
        /// It is an collection of objects, where each object contains information about a specific field and a corresponding error message.
        /// </summary>
        [SerializeField]
        [JsonProperty("fields")]
        public List<FieldError>? Fields { get; set; }
    }
}