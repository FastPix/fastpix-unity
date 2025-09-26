

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// The list of mediaId(s) you want to perform the operation on.rds by limit.
    /// </summary>
    [Serializable]
    public class MediaIdsRequest
    {

        [SerializeField]
        [JsonProperty("mediaIds")]
        public List<string> MediaIds { get; set; } = default!;
    }
}