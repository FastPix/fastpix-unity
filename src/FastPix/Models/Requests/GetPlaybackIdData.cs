

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class GetPlaybackIdData
    {

        /// <summary>
        /// The unique identifier for the playback ID.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Access policy for media content
        /// </summary>
        [SerializeField]
        [JsonProperty("accessPolicy")]
        public AccessPolicy? AccessPolicy { get; set; }
    }
}