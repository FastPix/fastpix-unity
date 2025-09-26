

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class DeleteSigningKeyRequest
    {

        /// <summary>
        /// When creating the signing key, FastPix assigns a universally unique identifier with a maximum length of 255 characters.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=signingKeyId")]
        public string SigningKeyId { get; set; } = default!;
    }
}