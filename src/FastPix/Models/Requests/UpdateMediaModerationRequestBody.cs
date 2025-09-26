

#nullable enable
namespace fastpix.io.Models.Requests
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    
    [Serializable]
    public class UpdateMediaModerationRequestBody
    {

        [SerializeField]
        [JsonProperty("moderation")]
        public UpdateMediaModerationModeration? Moderation { get; set; }
    }
}