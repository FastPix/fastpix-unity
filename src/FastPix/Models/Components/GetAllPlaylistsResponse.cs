

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class GetAllPlaylistsResponse
    {

        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [SerializeField]
        [JsonProperty("data")]
        public List<PlaylistItem>? Data { get; set; }

        /// <summary>
        /// Pagination organizes content into pages for better readability and navigation.
        /// </summary>
        [SerializeField]
        [JsonProperty("pagination")]
        public Pagination? Pagination { get; set; }
    }
}