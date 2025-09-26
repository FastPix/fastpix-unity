

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class GetPlaybackIdRequest
    {

        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=mediaId")]
        public string MediaId { get; set; } = default!;

        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=playbackId")]
        public string PlaybackId { get; set; } = default!;
    }
}