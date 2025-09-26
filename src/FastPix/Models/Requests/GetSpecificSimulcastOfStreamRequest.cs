

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class GetSpecificSimulcastOfStreamRequest
    {

        /// <summary>
        /// Upon creating a new live stream, FastPix assigns a unique identifier to the stream.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=streamId")]
        public string StreamId { get; set; } = default!;

        /// <summary>
        /// When you create the new simulcast, FastPix assign a universal unique identifier which can contain a maximum of 255 characters.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=simulcastId")]
        public string SimulcastId { get; set; } = default!;
    }
}