

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine.Networking;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    
    [Serializable]
    public class ListLiveClipsResponse: IDisposable
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
        /// List of video media
        /// </summary>
        [SerializeField]
        public ListLiveClipsResponseBody? Object { get; set; }
        public void Dispose() {
            if (RawResponse != null) {
                RawResponse.Dispose();
            }
        }
    }
}