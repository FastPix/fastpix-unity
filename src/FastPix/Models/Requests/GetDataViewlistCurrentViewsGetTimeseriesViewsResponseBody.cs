

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    
    /// <summary>
    /// Successfully retrieved concurrent viewers timeseries.
    /// </summary>
    [Serializable]
    public class GetDataViewlistCurrentViewsGetTimeseriesViewsResponseBody
    {

        /// <summary>
        /// Indicates if the request was successful.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Time series data for concurrent viewers.
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public List<GetDataViewlistCurrentViewsGetTimeseriesViewsData>? Data { get; set; }

        /// <summary>
        /// Start and end epoch timestamps (milliseconds) for the timeseries window.
        /// </summary>
        [SerializeField]
        [JsonProperty("timespan")]
        public List<long>? Timespan { get; set; }
    }
}