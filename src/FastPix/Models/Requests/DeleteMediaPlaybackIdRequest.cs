

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class DeleteMediaPlaybackIdRequest
    {

        /// <summary>
        /// Return the universal unique identifier for media which can contain a maximum of 255 characters.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=mediaId")]
        public string MediaId { get; set; } = default!;

        /// <summary>
        /// Return the universal unique identifier for playbacks  which can contain a maximum of 255 characters. 
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=playbackId")]
        public string PlaybackId { get; set; } = default!;
    }
}