

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class GetAllSigningKeyResponse
    {

        /// <summary>
        /// It demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Displays the result of the request.
        /// </summary>
        [SerializeField]
        [JsonProperty("data")]
        public List<GetAllSigningKeyResponseDTO>? Data { get; set; }
    }
}