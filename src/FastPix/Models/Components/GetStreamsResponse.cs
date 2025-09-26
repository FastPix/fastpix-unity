

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    /// <summary>
    /// Displays the result of the request.
    /// </summary>
    [Serializable]
    public class GetStreamsResponse
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
        public List<GetCreateLiveStreamResponseDTO>? Data { get; set; }

        /// <summary>
        /// Pagination organizes content into pages for better readability and navigation.
        /// </summary>
        [SerializeField]
        [JsonProperty("pagination")]
        public LiveStreamPagination? Pagination { get; set; }
    }
}