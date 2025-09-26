

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class NamedEntitiesResponse
    {

        [SerializeField]
        [JsonProperty("mediaId")]
        public string? MediaId { get; set; }

        [SerializeField]
        [JsonProperty("isGeneratedNamedEntities")]
        public bool? IsGeneratedNamedEntities { get; set; }
    }
}