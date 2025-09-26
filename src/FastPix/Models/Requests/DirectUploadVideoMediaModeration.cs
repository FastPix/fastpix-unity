

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class DirectUploadVideoMediaModeration
    {

        /// <summary>
        /// Type of media content
        /// </summary>
        [SerializeField]
        [JsonProperty("type")]
        public MediaType? Type { get; set; }
    }
}