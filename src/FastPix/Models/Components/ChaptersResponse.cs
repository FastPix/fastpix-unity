

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class ChaptersResponse
    {

        [SerializeField]
        [JsonProperty("mediaId")]
        public string? MediaId { get; set; }

        [SerializeField]
        [JsonProperty("isGeneratedChapters")]
        public bool? IsGeneratedChapters { get; set; }
    }
}