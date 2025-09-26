

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Models.Requests;
    using fastpix.io.Utils;
    
    [Serializable]
    public class UpdatedMp4SupportRequest
    {

        /// <summary>
        /// When creating the media, FastPix assigns a universally unique identifier with a maximum length of 255 characters.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=mediaId")]
        public string MediaId { get; set; } = default!;

        [SerializeField]
        [FastPixMetadata("request:mediaType=application/json")]
        public UpdatedMp4SupportRequestBody RequestBody { get; set; } = default!;
    }
}