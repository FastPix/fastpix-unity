

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class DeleteAPlaylistRequest
    {

        /// <summary>
        /// The unique id of the playlist you want to delete.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=playlistId")]
        public string PlaylistId { get; set; } = default!;
    }
}