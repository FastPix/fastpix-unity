

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class GetVideoViewDetailsRequest
    {

        /// <summary>
        /// Pass View id
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=viewId")]
        public string ViewId { get; set; } = default!;
    }
}