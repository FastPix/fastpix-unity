

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    using fastpix.io.Utils;
    
    [Serializable]
    public class GenerateSubtitleTrackRequest
    {

        /// <summary>
        /// A universally unique identifier (UUID) assigned to the media by FastPix.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=mediaId")]
        public string MediaId { get; set; } = default!;

        /// <summary>
        /// A universally unique identifier (UUID) assigned to the specific track for which subtitles should be generated.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=trackId")]
        public string TrackId { get; set; } = default!;

        [SerializeField]
        [FastPixMetadata("request:mediaType=application/json")]
        public TrackSubtitlesGenerateRequest TrackSubtitlesGenerateRequest { get; set; } = default!;
    }
}