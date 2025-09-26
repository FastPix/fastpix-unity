

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class DeletePlaybackIdOfStreamRequest
    {

        /// <summary>
        /// Upon creating a new live stream, FastPix assigns a unique identifier to the stream.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=streamId")]
        public string StreamId { get; set; } = default!;

        /// <summary>
        /// Unique identifier for the playbackId
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=playbackId")]
        public string PlaybackId { get; set; } = default!;
    }
}