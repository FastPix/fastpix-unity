

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class ModerationResponse
    {

        [SerializeField]
        [JsonProperty("mediaId")]
        public string? MediaId { get; set; }

        [SerializeField]
        [JsonProperty("isModerationEnabled")]
        public bool? IsModerationEnabled { get; set; }
    }
}