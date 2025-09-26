

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
    public class PlaylistCreatedSchema
    {

        /// <summary>
        /// Upon creating a new play,ist, FastPix assigns a unique identifier to the playlist.
        /// </summary>
        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The name to the playlist set by the user.
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
        /// Type will be either smart or manual, as sent in the request body.
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public PlaylistCreatedSchemaType? Type { get; set; }

        /// <summary>
        /// The description to the playlist set by the user.
        /// </summary>
        [SerializeField]
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Determines the insertion order of media into playlist.
        /// </summary>
        [SerializeField]
        [JsonProperty("playOrder")]
        public PlaylistOrder? PlayOrder { get; set; }

        /// <summary>
        /// date range filter used when creating the smart playlist
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public PlaylistCreatedSchemaMetadata? Metadata { get; set; }

        [SerializeField]
        [JsonProperty("mediaList")]
        public List<PlaylistCreatedSchemaMediaList>? MediaList { get; set; }

        /// <summary>
        /// Id of the workspace
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