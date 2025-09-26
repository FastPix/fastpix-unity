

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine.Networking;
    using UnityEngine;
    using fastpix.io.Models.Components;
    
    [Serializable]
    public class DeleteSigningKeyResponse: IDisposable
    {

        /// <summary>
        /// HTTP response content type for this operation
        /// </summary>
        [SerializeField]
        public string? ContentType { get; set; } = default!;

        /// <summary>
        /// HTTP response status code for this operation
        /// </summary>
        [SerializeField]
        public int StatusCode { get; set; } = default!;

        /// <summary>
        /// Raw HTTP response; suitable for custom response parsing
        /// </summary>
        [SerializeField]
        public UnityWebRequest RawResponse { get; set; } = default!;

        /// <summary>
        /// successfully fetched all signing keys
        /// </summary>
        [SerializeField]
        public fastpix.io.Models.Components.DeleteSigningKeyResponse? DeleteSigningKeyResponseValue { get; set; }
        public void Dispose() {
            if (RawResponse != null) {
                RawResponse.Dispose();
            }
        }
    }
}