

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    
    /// <summary>
    /// Successfully retrieved concurrent viewers breakdown by the specified dimension.
    /// </summary>
    [Serializable]
    public class GetDataViewlistCurrentViewsFilterResponseBody
    {

        /// <summary>
        /// Indicates if the request was successful.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Breakdown of concurrent viewers by the specified dimension.
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public List<GetDataViewlistCurrentViewsFilterData>? Data { get; set; }

        /// <summary>
        /// Start and end epoch timestamps (milliseconds) for the timespan window.
        /// </summary>
        [SerializeField]
        [JsonProperty("timespan")]
        public List<long>? Timespan { get; set; }
    }
}