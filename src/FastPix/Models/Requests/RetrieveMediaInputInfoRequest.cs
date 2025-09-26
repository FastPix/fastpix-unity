

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class RetrieveMediaInputInfoRequest
    {

        /// <summary>
        /// Pass the list of the input objects used to create the media, along with applied settings.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=mediaId")]
        public string MediaId { get; set; } = default!;
    }
}