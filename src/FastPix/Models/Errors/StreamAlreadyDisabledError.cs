

#nullable enable
namespace fastpix.io.Models.Errors
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine.Networking;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    public class StreamAlreadyDisabledError : Exception
    {

        /// <summary>
        /// Indicates whether the request was successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Contains details explaining why the request failed.
        /// </summary>
        [SerializeField]
        [JsonProperty("error")]
        public StreamAlreadyDisabledErrorError? Error { get; set; }

        /// <summary>
        /// Raw HTTP response; suitable for custom response parsing
        /// </summary>
        [SerializeField]
        [JsonProperty("-")]
        public UnityWebRequest? RawResponse { get; set; }
    }
}