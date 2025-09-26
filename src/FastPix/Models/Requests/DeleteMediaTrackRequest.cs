

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class DeleteMediaTrackRequest
    {

        /// <summary>
        /// When creating the media, FastPix assigns a universally unique identifier with a maximum length of 255 characters.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=mediaId")]
        public string MediaId { get; set; } = default!;

        /// <summary>
        /// When creating the media, FastPix assigns a universally unique identifier with a maximum length of 255 characters.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=trackId")]
        public string TrackId { get; set; } = default!;
    }
}