

#nullable enable
namespace fastpix.io.Models.Errors
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine.Networking;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    public class NotFoundError : Exception
    {

        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [SerializeField]
        [JsonProperty("error")]
        public NotFoundErrorError? Error { get; set; }

        /// <summary>
        /// Raw HTTP response; suitable for custom response parsing
        /// </summary>
        [SerializeField]
        [JsonProperty("-")]
        public UnityWebRequest? RawResponse { get; set; }
    }
}