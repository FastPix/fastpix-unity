

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Contains the view count details.
    /// </summary>
    [Serializable]
    public class ViewsCountResponseData
    {

        /// <summary>
        /// Number of views for the stream or resource.
        /// </summary>
        [SerializeField]
        [JsonProperty("views")]
        public long? Views { get; set; }
    }
}