

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class GetDrmConfigurationByIdRequest
    {

        /// <summary>
        /// The unique identifier of the DRM configuration.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("pathParam:style=simple,explode=false,name=drmConfigurationId")]
        public string DrmConfigurationId { get; set; } = default!;
    }
}