

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class PlaylistByIdResponseMediaList
    {

        /// <summary>
        /// Timestamp of media creation in the workspace.
        /// </summary>
        [SerializeField]
        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Duration of the media in hh:mm:ss format.
        /// </summary>
        [SerializeField]
        [JsonProperty("duration")]
        public string? Duration { get; set; }

        /// <summary>
        /// unique id of the particular media.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// source resolution of the media.
        /// </summary>
        [SerializeField]
        [JsonProperty("sourceResolution")]
        public string? SourceResolution { get; set; }

        /// <summary>
        /// status of the media, only media with ready status will be added to playlist.
        /// </summary>
        [SerializeField]
        [JsonProperty("status")]
        public string? Status { get; set; }

        /// <summary>
        /// thumbnail for the particular media.
        /// </summary>
        [SerializeField]
        [JsonProperty("thumbnail")]
        public string? Thumbnail { get; set; }
    }
}