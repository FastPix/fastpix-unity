

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Components;
    using fastpix.io.Utils;
    
    [Serializable]
    public class DeleteMediaFromPlaylistRequest
    {

        /// <summary>
        /// The unique id of the playlist you want to perform the operation on.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=playlistId")]
        public string PlaylistId { get; set; } = default!;

        [SerializeField]
        [FastPixMetadata("request:mediaType=application/json")]
        public MediaIdsRequest? MediaIdsRequest { get; set; }
    }
}