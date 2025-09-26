

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class CancelUploadRequest
    {

        /// <summary>
        /// When uploading the media, FastPix assigns a universally unique identifier with a maximum length of 255 characters.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=uploadId")]
        public string UploadId { get; set; } = default!;
    }
}