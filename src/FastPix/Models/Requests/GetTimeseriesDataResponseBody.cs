

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Get filter/ dimension value details by dimension name.
    /// </summary>
    [Serializable]
    public class GetTimeseriesDataResponseBody
    {

        /// <summary>
        /// It demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Retrieves breakdown values for a specified metric and timespan
        /// </summary>
        [SerializeField]
        [JsonProperty("metaData")]
        public MetricsTimeseriesMetaDataDetails? MetaData { get; set; }

        /// <summary>
        /// Displays the result of the request.
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public List<MetricsTimeseriesDataDetails>? Data { get; set; }

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