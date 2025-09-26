

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class PlaylistByIdResponseData
    {

        /// <summary>
        /// The unique id of the playlist
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The name of the playlist set by the user
        /// </summary>
        [SerializeField]
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Unique string value assigned by user to the playlist.
        /// </summary>
        [SerializeField]
        [JsonProperty("referenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// type of the playlist, when it was created
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public PlaylistByIdResponseType? Type { get; set; }

        /// <summary>
        /// Description of the playlist set by the user.
        /// </summary>
        [SerializeField]
        [JsonProperty("description")]
        public string? Description { get; set; }

        [SerializeField]
        [JsonProperty("mediaList")]
        public List<PlaylistByIdResponseMediaList>? MediaList { get; set; }

        /// <summary>
        /// The unique id of the workspace in which the playlist is present.
        /// </summary>
        [SerializeField]
        [JsonProperty("workspaceId")]
        public string? WorkspaceId { get; set; }

        /// <summary>
        /// Timestamp of playlist creation.
        /// </summary>
        [SerializeField]
        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Playlist&apos;s most recent update timestamp.
        /// </summary>
        [SerializeField]
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// No. of media present in the playlist
        /// </summary>
        [SerializeField]
        [JsonProperty("mediaCount")]
        public long? MediaCount { get; set; }
    }
}