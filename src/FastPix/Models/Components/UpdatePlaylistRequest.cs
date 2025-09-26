

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class UpdatePlaylistRequest
    {

        /// <summary>
        /// New name to the playlist.
        /// </summary>
        [SerializeField]
        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Updated description to the playlist.
        /// </summary>
        [SerializeField]
        [JsonProperty("description")]
        public string Description { get; set; } = default!;
    }
}