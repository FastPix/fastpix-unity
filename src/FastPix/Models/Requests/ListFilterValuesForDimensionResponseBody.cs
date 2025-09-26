

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Get filter / dimension value details by dimension name.
    /// </summary>
    [Serializable]
    public class ListFilterValuesForDimensionResponseBody
    {

        /// <summary>
        /// It demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// filter values associated with a specific dimension
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public List<BrowserNameDimensiondetails>? Data { get; set; }

        /// <summary>
        /// The timeframe from and to details displayed in the form of unix epoch timestamps.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("timespan")]
        public List<long>? Timespan { get; set; }
    }
}