

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    
    /// <summary>
    /// Successfully retrieved playback ID details
    /// </summary>
    [Serializable]
    public class GetPlaybackIdResponseBody
    {

        /// <summary>
        /// Indicates if the request was successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [SerializeField]
        [JsonProperty("data")]
        public GetPlaybackIdData? Data { get; set; }
    }
}