

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class PlaybackIdRequest
    {

        /// <summary>
        /// Basic access policy for media content
        /// </summary>
        [SerializeField]
        [JsonProperty("accessPolicy")]
        public BasicAccessPolicy? AccessPolicy { get; set; }
    }
}