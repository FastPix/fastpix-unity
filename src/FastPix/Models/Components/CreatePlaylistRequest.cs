

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class CreatePlaylistRequest
    {

        /// <summary>
        /// Name of the playlist.
        /// </summary>
        [SerializeField]
        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Unique string value assigned by user to the playlist.
        /// </summary>
        [SerializeField]
        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; } = default!;

        /// <summary>
        /// For a smart playlist metadata is required.
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public CreatePlaylistRequestType Type { get; set; } = default!;

        /// <summary>
        /// Description for a playlist (Optional).
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
        /// Optional parameter to limit no. of media in a playlist.
        /// </summary>
        [SerializeField]
        [JsonProperty("limit")]
        public long? Limit { get; set; }

        /// <summary>
        /// Required when playlist type is smart - media created between startDate and endDate of createdDate will be add, similarily updatedDate (Optional)
        /// </summary>
        [SerializeField]
        [JsonProperty("metadata")]
        public CreatePlaylistRequestMetadata? Metadata { get; set; }
    }
}