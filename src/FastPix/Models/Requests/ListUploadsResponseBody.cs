

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// List of video media
    /// </summary>
    [Serializable]
    public class ListUploadsResponseBody
    {

        /// <summary>
        /// Demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Displays the result of the request.
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public List<DirectUpload>? Data { get; set; }

        /// <summary>
        /// Pagination organizes content into pages for better readability and navigation.
        /// </summary>
        [SerializeField]
        [JsonProperty("pagination")]
        public Pagination? Pagination { get; set; }
    }
}