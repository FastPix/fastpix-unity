

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Get the list of Views
    /// </summary>
    [Serializable]
    public class ListVideoViewsResponseBody
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
        public List<ViewsList>? Data { get; set; }

        /// <summary>
        /// Pagination organizes content into pages for better readability and navigation.
        /// </summary>
        [SerializeField]
        [JsonProperty("pagination")]
        public DataPagination? Pagination { get; set; }

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