

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class PlaylistItem
    {

        [SerializeField]
        [JsonProperty("id")]
        public string? Id { get; set; }

        [SerializeField]
        [JsonProperty("name")]
        public string? Name { get; set; }

        [SerializeField]
        [JsonProperty("type")]
        public PlaylistItemType? Type { get; set; }

        [SerializeField]
        [JsonProperty("referenceId")]
        public string? ReferenceId { get; set; }

        [SerializeField]
        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [SerializeField]
        [JsonProperty("mediaCount")]
        public long? MediaCount { get; set; }
    }
}