

#nullable enable
namespace fastpix.io.Models.Requests
{
    using System;
    using UnityEngine;
    using fastpix.io.Utils;
    
    [Serializable]
    public class GetDrmConfigurationRequest
    {

        /// <summary>
        /// Offset determines the starting point for data retrieval within a paginated list.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=offset")]
        public long? Offset { get; set; }

        /// <summary>
        /// Limit specifies the maximum number of items to display per page.
        /// </summary>
        [SerializeField]
        [FastPixMetadata("queryParam:style=form,explode=true,name=limit")]
        public long? Limit { get; set; }
    }
}