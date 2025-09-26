

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Displays the result of the request.
    /// </summary>
    [Serializable]
    public class PlaybackIdSuccessResponse
    {

        /// <summary>
        /// It demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [SerializeField]
        [JsonProperty("data")]
        public PlaybackIdSuccessResponseData? Data { get; set; }
    }
}