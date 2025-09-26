

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class GetAllPlaylistsRequest
    {

        /// <summary>
        /// The number of playlists to return (default is 10, max is 50).
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=limit")]
        public long? Limit { get; set; }

        /// <summary>
        /// The page number to retrieve, starting from 1. Used for paginating the playlist results.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=offset")]
        public long? Offset { get; set; }
    }
}