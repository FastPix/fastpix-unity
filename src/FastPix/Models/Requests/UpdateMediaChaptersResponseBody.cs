

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Media details updated successfully with the chapters feature enabled or disabled
    /// </summary>
    [Serializable]
    public class UpdateMediaChaptersResponseBody
    {

        /// <summary>
        /// Indicates if the request was successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [SerializeField]
        [JsonProperty("data")]
        public ChaptersResponse? Data { get; set; }
    }
}