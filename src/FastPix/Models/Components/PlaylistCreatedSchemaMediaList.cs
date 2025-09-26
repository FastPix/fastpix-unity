

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class PlaylistCreatedSchemaMediaList
    {

        /// <summary>
        /// timestamp of media creation in the workspace
        /// </summary>
        [SerializeField]
        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// duration of the media in hh:mm:ss format
        /// </summary>
        [SerializeField]
        [JsonProperty("duration")]
        public string? Duration { get; set; }

        /// <summary>
        /// unique identifier of the media
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The source resolution of the media
        /// </summary>
        [SerializeField]
        [JsonProperty("sourceResolution")]
        public string? SourceResolution { get; set; }

        /// <summary>
        /// The status of the video in the workspace. Only media which are in ready status are added into the playlist
        /// </summary>
        [SerializeField]
        [JsonProperty("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Thumbnail to the particular media
        /// </summary>
        [SerializeField]
        [JsonProperty("thumbnail")]
        public string? Thumbnail { get; set; }
    }
}