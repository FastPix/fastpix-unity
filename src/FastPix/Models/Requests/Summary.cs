

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class Summary
    {

        /// <summary>
        /// Enable or disable the summary feature for the media. Set to true to enable summary or false to disable.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("generate")]
        public bool? Generate { get; set; }

        /// <summary>
        /// Specifies the desired word count for the generated summary. <br/>
        /// 
        /// <remarks>
        /// - The value must be between **30** and **250** words.<br/>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [JsonProperty("summaryLength")]
        public long? SummaryLength { get; set; }
    }
}