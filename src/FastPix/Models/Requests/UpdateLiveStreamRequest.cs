

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    using fastpix.io.Utils;
    
    [Serializable]
    public class UpdateLiveStreamRequest
    {

        /// <summary>
        /// Upon creating a new live stream, FastPix assigns a unique identifier to the stream.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=streamId")]
        public string StreamId { get; set; } = default!;

        [SerializeField]
        [FastPixMetadata("request:mediaType=application/json")]
        public PatchLiveStreamRequest PatchLiveStreamRequest { get; set; } = default!;
    }
}