

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    using fastpix.io.Utils;
    
    [Serializable]
    public class CreateMediaPlaybackIdRequest
    {

        /// <summary>
        /// When creating the media, FastPix assigns a universally unique identifier with a maximum length of 255 characters.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=mediaId")]
        public string MediaId { get; set; } = default!;

        /// <summary>
        /// Request body for creating playback id for an media
        /// </summary>
        [SerializeField]
        [FastPixMetadata("request:mediaType=application/json")]
        public CreateMediaPlaybackIdRequestBody? RequestBody { get; set; }
    }
}