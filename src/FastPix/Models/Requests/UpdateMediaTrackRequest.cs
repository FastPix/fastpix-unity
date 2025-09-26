

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    using fastpix.io.Utils;
    
    [Serializable]
    public class UpdateMediaTrackRequest
    {

        /// <summary>
        /// When creating the media, FastPix assigns a universally unique identifier with a maximum length of 255 characters.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=trackId")]
        public string TrackId { get; set; } = default!;

        /// <summary>
        /// When creating the media, FastPix assigns a universally unique identifier with a maximum length of 255 characters.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=mediaId")]
        public string MediaId { get; set; } = default!;

        [SerializeField]
        [FastPixMetadata("request:mediaType=application/json")]
        public UpdateTrackRequest UpdateTrackRequest { get; set; } = default!;
    }
}