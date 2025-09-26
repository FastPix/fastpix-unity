

#nullable enable
namespace fastpix.io.Models.Errors
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine.Networking;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    public class UnAuthorizedResponseException : Exception
    {

        /// <summary>
        /// It demonstrates whether the request is successful or not.
        /// </summary>
        [SerializeField]
        [JsonProperty("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Displays details about the reasons behind the request&apos;s failure.
        /// </summary>
        [SerializeField]
        [JsonProperty("error")]
        public UnAuthorizedResponseError? Error { get; set; }

        /// <summary>
        /// Raw HTTP response; suitable for custom response parsing
        /// </summary>
        [SerializeField]
        [JsonProperty("-")]
        public UnityWebRequest? RawResponse { get; set; }
    }
}