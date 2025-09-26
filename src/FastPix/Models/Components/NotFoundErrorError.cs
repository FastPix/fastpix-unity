

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    [Serializable]
    public class NotFoundErrorError
    {

        [SerializeField]
        [JsonProperty("code")]
        public long? Code { get; set; }

        [SerializeField]
        [JsonProperty("message")]
        public string? Message { get; set; }

        [SerializeField]
        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}