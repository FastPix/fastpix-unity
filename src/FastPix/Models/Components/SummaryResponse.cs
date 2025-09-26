

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class SummaryResponse
    {

        [SerializeField]
        [JsonProperty("mediaId")]
        public string? MediaId { get; set; }

        [SerializeField]
        [JsonProperty("isGeneratedSummary")]
        public bool? IsGeneratedSummary { get; set; }
    }
}