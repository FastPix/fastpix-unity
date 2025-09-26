

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class FieldError
    {

        /// <summary>
        /// Displays the specific field associated with the error.
        /// </summary>
        [SerializeField]
        [JsonProperty("field")]
        public string Field { get; set; } = default!;

        /// <summary>
        /// Error message for the field
        /// </summary>
        [SerializeField]
        [JsonProperty("message")]
        public string Message { get; set; } = default!;
    }
}