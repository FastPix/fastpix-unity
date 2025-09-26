

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class ViewsCountResponse
    {

        /// <summary>
        /// Indicates whether the request was successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Contains the view count details.
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public ViewsCountResponseData? Data { get; set; }
    }
}