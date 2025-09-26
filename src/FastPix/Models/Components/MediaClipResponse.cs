

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class MediaClipResponse
    {

        [SerializeField]
        [JsonProperty("success")]
        public bool Success { get; set; } = default!;

        [SerializeField]
        [JsonProperty("data")]
        public List<MediaClipResponseData> Data { get; set; } = default!;

        [SerializeField]
        [JsonProperty("pagination")]
        public MediaClipResponsePagination Pagination { get; set; } = default!;
    }
}