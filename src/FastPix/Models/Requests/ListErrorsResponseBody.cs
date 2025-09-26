

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    
    /// <summary>
    /// Get filter/ dimension value details by dimension name.
    /// </summary>
    [Serializable]
    public class ListErrorsResponseBody
    {

        /// <summary>
        /// It demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Displays the result of the request.
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public ListErrorsData? Data { get; set; }

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