

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class GetLiveStreamPlaybackIdRequest
    {

        /// <summary>
        /// Upon creating a new live stream, FastPix assigns a unique identifier to the stream.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=streamId")]
        public string StreamId { get; set; } = default!;

        /// <summary>
        /// Upon creating a new playbackId, FastPix assigns a unique identifier to the playback.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=playbackId")]
        public string PlaybackId { get; set; } = default!;
    }
}